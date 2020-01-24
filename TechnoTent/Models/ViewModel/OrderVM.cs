using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnoTent.Models.InTimeAPI;

namespace TechnoTent.Models.ViewModel
{
    public class OrderVM
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
        public List<OrderItemsVM> Items { get; set; }
        //new
        public List<string> ItemsNameList { get; set; }
        public List<string> ItemsImagesList { get; set; }
        //
        public List<string> ItemsVendorCodeList { get; set; }
        public string ItemsPrice { get; set; }
        public List<string> ItemsPriceList { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItemsCount { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderLanguage { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Guid, string> NovaPoshtaCities { get; set; }
        public List<string> NovaPoshtaCitiePostOffice { get; set; }
        public Dictionary<long, string> InTimeCiites { get; set; }
        public List<string> InTimeCitiePostOffice { get; set; }
    }
}