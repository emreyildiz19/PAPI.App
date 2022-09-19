using Microsoft.EntityFrameworkCore;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithAll()
        {
            return
             await _context.Products.Include(x => x.Category).Include(s=>s.Brand).Include(s=>s.ProductPhotos).ToListAsync();

        }
    }
}
