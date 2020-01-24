using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleUa { get; set; }
        public string TitleEn { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string TextRu { get; set; }
        public string TextUa { get; set; }
        public string TextEn { get; set; }
        public DateTime DateTime { get; set; }
        public List<NewsVM> NewsList { get; set; }
    }
}