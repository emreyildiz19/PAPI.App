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
    public class PhotosWithProductRepository : GenericRepository<ProductPhoto>, IPhotoRepository
    {
        public PhotosWithProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ProductPhoto>> GetPhotosWithProduct()
        {
            return await _context.ProductPhotos.Include(x => x.Product).ToListAsync();
             
        }
    }
}
