using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class AdminReviews
    {
        public static void AnswerReview(ReviewVM review)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var user = db.ReviewDb.Where(u => u.Id == review.Id).FirstOrDefault();

                user.Answer = review.Answer;
                user.AnswerDateTime = DateTime.Now;

                db.SaveChanges();
            }
        }

        public static void DeleteReview(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var review = db.ReviewDb.Where(u => u.Id == id).FirstOrDefault();

                db.ReviewDb.Remove(review);

                db.SaveChanges();
            }
        }

        public static void DeleteAllReviews(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var review = db.ReviewDb;

                foreach (var data in review)
                {
                    db.ReviewDb.Remove(data);

                    db.SaveChanges();
                }
            }
        }
    }
}