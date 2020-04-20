using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class OrderItemsVM
    {
        public string ItemName { get; set; }
        public string ItemImages { get; set; }
        public string ItemCount { get; set; }
        public string ItemVendorCode { get; set; }
        public string ItemPrice { get; set; }
        public string ItemtotalPrice { get; set; }
        public bool ProductBuyTypeMeter { get; set; }
        public string ItemMinOrder { get; set; }
        public string ItemDescription { get; set; }
        public string ItemUrl { get; set; }
    }
}