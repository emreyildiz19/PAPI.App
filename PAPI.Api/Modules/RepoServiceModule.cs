using Autofac;
//using PAPI.Caching;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using PAPI.Repository.Repositories;
using PAPI.Repository.UnitOfWorks;
using PAPI.Repository;
using PAPI.Service.Mapping;
using PAPI.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace PAPI.Api.Modules
{
    public class RepoServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWorks>().InstancePerLifetimeScope();


            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithNoCaching>().As<IProductService>();
            


            base.Load(builder);
        }

    }
}

