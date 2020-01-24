using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class MainImagesVM
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public HttpPostedFileBase[] Images { get; set; }
        public string Image { get; set; }
        public List<MainImagesVM> MainImages { get; set; }
    }
}