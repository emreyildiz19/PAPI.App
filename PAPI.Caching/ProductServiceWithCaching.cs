using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using PAPI.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace PAPI.Caching
//{
    // public class ProductServiceWithCaching : IProductService
    //{
    //    private const string CacheProductKey = "productsCache";
    //    private readonly IMapper _mapper;
        //private readonly IMemoryCache _memoryCache;
    //    private readonly IProductRepository _repository;
    //    private readonly IUnitOfWorks _unitOfWork;

    //    public ProductServiceWithCaching(IUnitOfWorks unitOfWork, IProductRepository repository, IMemoryCache memoryCache, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _repository = repository;
    //       _memoryCache = memoryCache;
    //        _mapper = mapper;

    //        if (!_memoryCache.TryGetValue(CacheProductKey, out _))
    //        {
    //            _memoryCache.Set(CacheProductKey, _repository.GetProductsWithAll().Result);

    //        }

    //    }

    //    public async Task<Product> AddAsync(Product entity)
    //    {
    //        await _repository.AddAsync(entity);
    //        await _unitOfWork.CommitAsync();
    //        await CacheAllProductsAsync();
    //        return entity;

    //    }

    //    public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
    //    {
    //        await _repository.AddRangeAsync(entities);
    //        await _unitOfWork.CommitAsync();
    //        await CacheAllProductsAsync();
    //        return entities;
    //    }

    //    public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Product>> GetAllAsync()
    //    {
    //        return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
    //    }

    //    public Task<Product> GetByIdAsync(int id)
    //    {
    //        var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

    //        if (product == null)
    //        {
    //            throw new NotFoundException($"{typeof(Product).Name}({id}not found ");
    //        }
    //        return Task.FromResult(product);
    //    }

    //    public async Task<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>> GetProductsWithAll()
    //    {
    //        var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
    //        var productsWithCategoryDto = _mapper.Map<List<ProductWithBrandCategoryAndPhotos>>(products);
    //        return await Task.FromResult(CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>.Succes(200, productsWithCategoryDto));
    //    }

    //    public async Task RemoveAsync(Product entity)
    //    {
    //        _repository.Remove(entity);
    //        await _unitOfWork.CommitAsync();
    //        await CacheAllProductsAsync();
    //    }

    //    public async Task RemoveRangeAsync(IEnumerable<Product> entities)
    //    {
    //        _repository.RemoveRange(entities);
    //        await _unitOfWork.CommitAsync();
    //        await CacheAllProductsAsync();
    //    }

    //    public async Task UpdateAsync(Product entity)
    //    {
    //        _repository.Update(entity);
    //        await _unitOfWork.CommitAsync();
    //        await CacheAllProductsAsync();
    //    }

    //    public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
    //    {
    //        return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
    //    }
    //    public async Task CacheAllProductsAsync()
    //    {

    //        _memoryCache.Set(CacheProductKey, await _repository.GetProductsWithAll());
    //    }

    //}
//}
