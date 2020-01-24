using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class ReviewVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public bool Anonymous { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string Answer { get; set; }
        public DateTime AnswerDateTime { get; set; }
        public List<ReviewVM> reviews { get; set; }
    }
}