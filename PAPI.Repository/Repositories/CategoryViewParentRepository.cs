using Microsoft.EntityFrameworkCore;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Repository.Repositories
{
    public class CategoryViewParentRepository : GenericRepository<Category>, ICategoryViewParentRepository
    {
        public CategoryViewParentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoryWithParent()
        {
            return await _context.Categories.Include(x => x.Parent).ToListAsync();
        }

        //public async Task<List<CategoryViewDto>> GetCategoryWithParent()
        //{
        //    return await _context.CategoryViewDtos.Include(x => x.ParentName).ToListAsync();
        //}
    }
}
