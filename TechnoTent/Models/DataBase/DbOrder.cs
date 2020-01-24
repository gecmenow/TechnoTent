using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.DataBase
{
    public class DbOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryOffice { get; set; }
        public string DeliveryMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string ItemsVendorCode { get; set; }
        public string ItemsCount { get; set; }
        public int TotalitemsCount { get; set; }
        public string ItemsPrice { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderLanguage { get; set; }
        public DateTime Date { get; set; }
    }
}