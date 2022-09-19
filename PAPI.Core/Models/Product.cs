using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public int ParentCategoryId { get; set; }

        public int ChildCategoryId { get; set; }

        public int BrandId { get; set; }

        public int IsActive { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
