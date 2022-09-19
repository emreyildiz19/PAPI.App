using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.Models
{
    public class ProductPhoto:BaseEntity
    {
        public int ProductId { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public int IsActive { get; set; }

        public Product Product { get; set; }
    }
}
