using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PAPI.Api.Filters;
using PAPI.Api.Middlewares;
using PAPI.Api.Modules;
using PAPI.Caching.Redis;
using PAPI.Caching;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using PAPI.Repository;
using PAPI.Repository.Repositories;
using PAPI.Repository.UnitOfWorks;
using PAPI.Service.Mapping;
using PAPI.Service.Services;
using PAPI.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
options.Configuration = "localhost:6379";
    
});

builder.Services.ConfigureAll<ApiBehaviorOptions>(options =>
{

    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped(typeof(NotFoundFilter<>));

//builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(ICategoryViewParentRepository), typeof(CategoryViewParentRepository));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryViewParentService));
builder.Services.AddScoped(typeof(IPhotoRepository), typeof(PhotosWithProductRepository));
//builder.Services.AddScoped(typeof(IPhotoService), typeof(PhotosWithProductService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductServiceWithNoCaching));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSingleton<RedisServer>();
builder.Services.AddSingleton<ICacheService, RedisCacheService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {

        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);

    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
    RequestPath = new PathString("/Images")
});

app.Run();
