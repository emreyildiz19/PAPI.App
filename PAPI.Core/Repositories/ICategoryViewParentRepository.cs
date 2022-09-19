using PAPI.Core.DTOs;
using PAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Repositories
{
    public interface ICategoryViewParentRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoryWithParent();
    }
}
