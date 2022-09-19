using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.DTOs
{
    public class ProductWithBrandCategoryAndPhotos:ProductDto
    {
        public CategoryDto Category { get; set; }

        public BrandDto Brand { get; set; }
        public List<ProductPhotoDto> ProductPhotos { get; set; }

    }
}
