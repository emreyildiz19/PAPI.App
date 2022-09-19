using PAPI.Core.DTOs;
using PAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<List<CategoryViewDto>>> GetCategoryWithParent();
    }
}
