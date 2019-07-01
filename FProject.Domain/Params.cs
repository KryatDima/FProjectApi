using System;
using System.Collections.Generic;
using System.Text;

namespace FProject.Domain
{
    public class Params
    {
        public long? BrandId { get; set; }
        public long? TypeId { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
    }
}
