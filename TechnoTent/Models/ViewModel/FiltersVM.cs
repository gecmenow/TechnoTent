using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class FiltersVM
    {
        public string CategoryName { get; set; }
        public List<string> Brands { get; set; }
        public List<string> Colors { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public List<string> BrandsForFilters { get; set; }
    }
}