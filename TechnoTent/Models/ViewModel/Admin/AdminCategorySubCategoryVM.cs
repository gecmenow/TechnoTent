using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel.Admin
{
    public class AdminCategorySubCategoryVM
    {
        public List<AdminCategoryVM> AdminCategoryVM { get; set; }
        public List<AdminSubCategoryVM> AdminSubCategoryVM { get; set; }
    }
}