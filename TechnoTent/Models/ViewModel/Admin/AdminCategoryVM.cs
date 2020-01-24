using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminCategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameRu { get; set; }
        public string CategoryNameUa { get; set; }
        public string CategoryNameEn { get; set; }
    }
}