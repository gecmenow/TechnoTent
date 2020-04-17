using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.DataBase;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Models
{
    public class Partners
    {
        public static List<PartnersVM> GetPartners()
        {
            List<PartnersVM> partners = new List<PartnersVM>();

            using(DataBaseContext db = new DataBaseContext())
            {
                partners = db.PartnersDb.Select(x => new PartnersVM
                { ImagePath = x.ImagePath }).ToList();
            }

            return partners;
        }
    }
}