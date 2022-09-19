using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }

        public string title { get; set; }

        public int ParentCategoryId { get; set; }

        public int ChildCategoryId { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int IsActive { get; set; }

    }
}
