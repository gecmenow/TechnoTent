using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.ViewModel
{
    public class CartVM
    {
        public List<CartItemVM> CartItems { get; set; }
        public double TotalCost { get; set; }
        public int ItemsCount { get; set; }
    }
}