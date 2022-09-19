using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Services;

namespace PAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Brand> _service;

        public BrandsController(IService<Brand> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var brands = await _service.GetAllAsync();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());
            return CreateActionResult(CustomResponseDto<List<BrandDto>>.Succes(200, brandsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return CreateActionResult(CustomResponseDto<BrandDto>.Succes(200, brandDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandDto brandsDto)
        {
            var brand = await _service.AddAsync(_mapper.Map<Brand>(brandsDto));
            var brandDto = _mapper.Map<BrandDto>(brand);
            return CreateActionResult(CustomResponseDto<BrandDto>.Succes(201, brandDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandUpdateDto brandDto)
        {

            //var updateCategory = await _service.GetByIdAsync(id);
            await _service.UpdateAsync(_mapper.Map<Brand>(brandDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(brand);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(200));
        }
    }
}
