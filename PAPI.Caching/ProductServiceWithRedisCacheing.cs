using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Caching
{
    public class ProductServiceWithRedisCacheing : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWorks _unitOfWork;

        public ProductServiceWithRedisCacheing(IMapper mapper, IDistributedCache distributedCache, IProductRepository repository, IUnitOfWorks unitOfWork)
        {
            _mapper = mapper;
            _distributedCache = distributedCache;
            _repository = repository;
            _unitOfWork = unitOfWork;
            
                        
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>> GetProductsWithAll()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }
        
        public async Task CacheAllProductsAsync()
        {
            _distributedCache.SetAsync(CacheProductKey, null);

        }
    }
}
