using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class ItemsOutputVM
    {
        public List<ItemsVM> Items { get; set; }
        public List<FiltersVM> Filters { get; set; }
        public List<string> Colors { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double PriceMax { get; set; }
        public double PriceMin { get; set; }
    }
}