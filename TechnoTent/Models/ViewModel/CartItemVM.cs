using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class CartItemVM
    {
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public string NameUrl { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public double ItemPrice { get; set; }
        public string ItemCount { get; set; }
        public double ItemTotalPrice { get; set; }
        public double MinOrderQuantity { get; set; }
        public bool ProductBuyTypeMeter { get; set; }
    }
}