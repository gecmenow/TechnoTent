using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class CategoriesVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryVM> SubCategory { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryUrl { get; set; }
    }
}