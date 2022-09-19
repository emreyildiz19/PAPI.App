using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPI.Core.DTOs
{
    public  class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int Code { get; set; }

        public int IsActive { get; set; }

    }
}
