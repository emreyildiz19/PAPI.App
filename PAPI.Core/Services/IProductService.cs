using PAPI.Core.DTOs;
using PAPI.Core.Models;

namespace PAPI.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithBrandCategoryAndPhotos>>> GetProductsWithAll();
    }
}
