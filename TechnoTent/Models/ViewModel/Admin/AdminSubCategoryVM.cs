using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminSubCategoryVM
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryNameRu { get; set; }
        public string SubCategoryNameUa { get; set; }
        public string SubCategoryNameEn { get; set; }
        public List<AdminCategoryVM> adminCategoryVM { get; set; }
    }
}