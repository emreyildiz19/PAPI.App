using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAPI.Caching;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Services;
using PAPI.Service.Services;
using RabbitMQ.Client;
using StackExchange.Redis;
using System.Text;

namespace PAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private ICacheService _cacheService;
        //private readonly RabbitMQService _rabbitMQService;

        public ProductsController(IMapper mapper, IService<Product> service,
            IProductService productService, ICacheService cacheService)
        {
            _mapper = mapper;
            _service = service;
            _productService = productService;
            _cacheService = cacheService;
            //_rabbitMQService = rabbitMQService;
        }

        private readonly IService<Product> _service;
        private readonly IProductService _productService;


        [HttpGet("[action]")]

        public async Task<IActionResult> GetProductsWithAll()
        {
            const string redisProductKey= "productsWithAll";
            
            if (_cacheService.Any(redisProductKey))
            {
                var resultCacheData = _cacheService.Get<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>>(redisProductKey);
                return CreateActionResult(resultCacheData);
            }

            var resultData = await _productService.GetProductsWithAll();
            _cacheService.Add(redisProductKey, resultData, TimeSpan.FromDays(1)); 
            return CreateActionResult (resultData); 
        }
       
        [HttpGet]
        
        public async Task<IActionResult> All()
        {
            const string redisProductKey = "products";

            if (_cacheService.Any(redisProductKey))
            {
                var resultCacheData = _cacheService.Get<CustomResponseDto<List<ProductDto>>>(redisProductKey);
                return CreateActionResult(resultCacheData);
            }
            
            var resultData = await _productService.GetAllAsync();
            
            var resultDataDto = _mapper.Map<List<ProductDto>>(resultData.ToList());
            _cacheService.AddList(redisProductKey, resultData, TimeSpan.FromDays(1));
            
             
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, resultDataDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            const string redisProductKey = "productWithId";

            if (_cacheService.Any(redisProductKey))
            {
                var resultCacheData = _cacheService.Get<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>>(redisProductKey);
                return CreateActionResult(resultCacheData);
            }

            var resultData = await _productService.GetByIdAsync(id);

            var resultDataDto = _mapper.Map<ProductWithBrandCategoryAndPhotos>(resultData);
            _cacheService.Add(redisProductKey, resultData, TimeSpan.FromDays(1));


            return CreateActionResult(CustomResponseDto<ProductWithBrandCategoryAndPhotos>.Succes(200, resultDataDto));

            //var product = await _productService.GetByIdAsync(id);
            //var productsDto = _mapper.Map<ProductWithBrandCategoryAndPhotos>(product);
            //return CreateActionResult(CustomResponseDto<ProductWithBrandCategoryAndPhotos>.Succes(200, productsDto)); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto) 
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));  
            var rabbitsDto = _mapper.Map<ProductWithBrandCategoryAndPhotos>(productDto);
            var productsDto = _mapper.Map<ProductDto>(product);
            
            _cacheService.Remove("products");
            _cacheService.Remove("productsWithAll");
            _cacheService.Remove("productsWithId");


            //static void Main(CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>> productDto)
            //{

                var factory = new ConnectionFactory();
                factory.Uri = new Uri("amqps://cwiaqspq:qFvwpyFVFIvKkHecif-wj9K4ohcBTKCK@hawk.rmq.cloudamqp.com/cwiaqspq");

                using var connection = factory.CreateConnection();

                var channel = connection.CreateModel();

                channel.QueueDeclare("papi-product", true, false, false);

            var message = Newtonsoft.Json.JsonConvert.SerializeObject(rabbitsDto);

            var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty, "papi-product", null, messageBody);


                

           // }
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(201, productsDto));
         
        }


       

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            _cacheService.Remove("products");
            _cacheService.Remove("productsWithAll");
            _cacheService.Remove("productsWithId");
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            _cacheService.Remove("products");
            _cacheService.Remove("productsWithAll");
            _cacheService.Remove("productsWithId");
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(200));
        }
    }
}
