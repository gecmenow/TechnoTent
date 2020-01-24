using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool Anonymous { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string Answer { get; set; }
        public DateTime AnswerDateTime { get; set; }
    }
}