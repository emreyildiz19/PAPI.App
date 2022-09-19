using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public int IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
