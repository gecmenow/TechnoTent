using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbCategory
    {
        public int Id { get; set; }
        public string CategoryNameUa { get; set; }
        public string CategoryNameRu { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryImage { get; set; }
    }
}