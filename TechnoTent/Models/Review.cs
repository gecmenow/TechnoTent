using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Review
    {
        public static List<ReviewVM> GetReviews()
        {
            List<ReviewVM> data = new List<ReviewVM>();

            using (DataBaseContext db = new DataBaseContext())
            {
                data = 
                    (from entry in db.ReviewDb
                     select new ReviewVM
                     {
                         Id = entry.Id,
                         UserId = entry.UserId,
                         Text = entry.Text,
                         Title = entry.Title,
                         Anonymous = entry.Anonymous,
                         DateTime = entry.DateTime,
                         Answer = entry.Answer,
                         AnswerDateTime = entry.AnswerDateTime,
                     }).ToList();

                foreach (var review in data)
                    review.UserName = db.UserDb.Where(u => u.Id == review.UserId).FirstOrDefault().Name;
            }

            return data;
        }

        public static void AddReview(ReviewVM reviewVM, string session)
        {
            int id = Convert.ToInt32(session);

            if (reviewVM.Title == null)
                reviewVM.Title = " ";

            using (DataBaseContext db = new DataBaseContext())
            {
                db.ReviewDb.Add(new DbReview
                {
                    Text = reviewVM.Text,
                    Title = reviewVM.Title,
                    Anonymous = reviewVM.Anonymous,
                    
                    UserId = id,
                    DateTime = DateTime.Now,
                    AnswerDateTime = DateTime.Now,
                });

                db.SaveChanges();
            }
        }
    }
}