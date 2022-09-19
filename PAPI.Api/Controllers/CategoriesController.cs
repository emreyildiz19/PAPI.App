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
    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Category> _service;
        private readonly ICategoryService _categoryService;
        public CategoriesController(IMapper mapper, IService<Category> service ,ICategoryService categoryService)
        {
            _mapper = mapper;
            _service = service;
            _categoryService = categoryService;
        }

        [HttpGet("[action]")]
        
        public async Task<IActionResult> GetCategoriesWithParent()
        {
            return CreateActionResult(await _categoryService.GetCategoryWithParent());

        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Succes(200, categoriesDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryViewDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryViewDto>.Succes(200, categoryDto));
        }

        [HttpPost]
         public async Task<IActionResult> Save(CategoryDto categoriesDto)
        {
            var category = await _service.AddAsync(_mapper.Map<Category>(categoriesDto));
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Succes(201, categoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryDto)
        {

            //var updateCategory = await _service.GetByIdAsync(id);
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(200));
        }

    }
}
