using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Feedback
    {
        public static void AddFeedback(FeedbackVM feedbackVM)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.FeedbackDb.Add(
                    new DbFeedback
                    {
                        Name = feedbackVM.Name,
                        Email = feedbackVM.Email,
                        Tel = feedbackVM.Tel,
                        Message = feedbackVM.Message,
                        DateTime = DateTime.Now,
                    });

                db.SaveChanges();
            }
        }
    }
}