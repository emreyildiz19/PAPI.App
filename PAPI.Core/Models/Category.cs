using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Models
{
    public  class Category : BaseEntity
    {
        public string Name { get; set; }


        public int Code { get; set; }

        public int IsActive { get; set; }

        public int? ParentId { get; set; }
        public Category? Parent { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
