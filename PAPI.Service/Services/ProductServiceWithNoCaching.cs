using AutoMapper;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWorks unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>> GetProductsWithAll()
        {
            var products = await _productRepository.GetProductsWithAll();

            var productsDto = _mapper.Map<List<ProductWithBrandCategoryAndPhotos>>(products);
            return CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>.Succes(200, productsDto);
        }
    }
}
