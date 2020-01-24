using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbStocks
    {
        public int Id { get; set; }
        [Required]
        public string TitleRu { get; set; }
        public string TitleUa { get; set; }
        public string TitleEn { get; set; }
        public string Image { get; set; }
        [Required]
        public string TextRu { get; set; }
        public string TextUa { get; set; }
        public string TextEn { get; set; }
        public DateTime DateTime { get; set; }

    }
}