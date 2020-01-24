using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class HomeVM
    {
        public List<MainImagesVM> mainImages { get; set; }
        public List<StocksVM> stokcs { get; set; }
        public List<NewsVM> news { get; set; }
    }
}