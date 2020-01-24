using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class SubCategoryVM
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryImage { get; set; }
        public string SubCategoryUrl { get; set; }
    }
}