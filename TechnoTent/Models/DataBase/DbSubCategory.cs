using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbSubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryNameRu { get; set; }
        public string SubCategoryNameUa { get; set; }
        public string SubCategoryNameEn { get; set; }
        public string SubCategoryImage { get; set; }
    }
}