using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TechnoTent.Models
{
    public class Exchange
    {
        public string Date { get; set; }
        public string rate { get; set; }
        public static Exchange GetExchange()
        {
            Exchange exchange = new Exchange();

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            date = date.Replace("-", "");

            var json = new WebClient().DownloadString("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?valcode=USD&date=" + date + "&json");

            dynamic stuff = JsonConvert.DeserializeObject<List<Exchange>>(json);

            exchange.Date = DateTime.Now.ToString("yyyy/MM/dd");
            exchange.rate = stuff[0].rate;

            return exchange;
        }
    }
}