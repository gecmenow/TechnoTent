using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;

namespace TechnoTent.Models
{
    public class AdminFeedback
    {
        public static void DelteFeedback(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var feedback = db.FeedbackDb.Where(u => u.Id == id).FirstOrDefault();

                db.FeedbackDb.Remove(feedback);

                db.SaveChanges();
            }
        }

        public static void DeleteAllFeedbacks()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var feedback = db.FeedbackDb;

                foreach (var data in feedback)
                {
                    db.FeedbackDb.Remove(data);

                    db.SaveChanges();
                }
            }
        }
    }
}