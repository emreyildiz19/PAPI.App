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
    public class CategoryViewParentService : Service<Category>, ICategoryService
    {
        private readonly ICategoryViewParentRepository _parentRepository;
        private readonly IMapper _mapper;
        public CategoryViewParentService(IGenericRepository<Category> repository, IUnitOfWorks unitOfWork, ICategoryViewParentRepository parentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CategoryViewDto>>> GetCategoryWithParent()
        {
            var parents = await _parentRepository.GetCategoryWithParent();

            var parentsDto = _mapper.Map<List<CategoryViewDto>>(parents);
            return CustomResponseDto<List<CategoryViewDto>>.Succes(200, parentsDto);
        }
    }
}
