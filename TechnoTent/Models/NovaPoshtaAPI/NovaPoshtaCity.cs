using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace TechnoTent.Models.NovaPoshtaAPI
{
    public class NovaPoshtaCity
    {
        static Dictionary<Guid, string> GetCity(string city)
        {
            string key = Admin.GetAdminData().NovaPoshtaKey;

            string json = @"{
                ""apiKey"": """ + key + @""",
                 ""modelName"": ""Address"",
                    ""calledMethod"": ""searchSettlements"",
                    ""methodProperties"": {
                        ""CityName"": """ + city + @""",
                        ""Limit"": 10
                    }
            }";

            var httpRequest = (HttpWebRequest)WebRequest.Create("http://api.novaposhta.ua/v2.0/json/Address/searchSettlements/");
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";

            string response = "";

            using (var requestStream = httpRequest.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.Write(json);
            }
            using (var httpResponse = httpRequest.GetResponse())
            using (var responseStream = httpResponse.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                response = reader.ReadToEnd();
            }

            NovaPoshtaCityKeyModel novaPoshtaCityKeys = NovaPoshtaCityKeyModel.FromJson(response);

            Dictionary<Guid, Guid> citiesKeys = new Dictionary<Guid, Guid>();

            foreach (var data in novaPoshtaCityKeys.Data)
                foreach (var address in data.Addresses)
                {
                    if (citiesKeys.Count != 10)
                    {
                        if (address.Warehouses != 0)
                            citiesKeys.Add(address.Ref, address.DeliveryCity);
                    }
                    else
                        break;
                }

            Dictionary<Guid, string> cities = new Dictionary<Guid, string>();

            foreach (var entry in citiesKeys)
            {
                json = @"{
                     ""modelName"": ""AddressGeneral"",
                        ""calledMethod"": ""getSettlements"",
                        ""methodProperties"": {
                                ""Ref"": """ + entry.Key + @"""
                            },
                        ""apiKey"": """ + key + @"""
                }";

                httpRequest = (HttpWebRequest)WebRequest.Create("http://api.novaposhta.ua/v2.0/json/Address/getSettlements");
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";

                response = "";

                using (var requestStream = httpRequest.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
                using (var httpResponse = httpRequest.GetResponse())
                using (var responseStream = httpResponse.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    response = reader.ReadToEnd();
                }

                NovaPoshtaCityModel novaPoshta = NovaPoshtaCityModel.FromJson(response);

                var language = Cookies.Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        foreach (var data in novaPoshta.Data)
                            if (cities.Count != 10)
                                if (data.Warehouse != 0)
                                    cities.Add(entry.Value, data.Description + ", " + data.AreaDescription);
                        break;
                    case "en":
                        foreach (var data in novaPoshta.Data)
                            if (cities.Count != 10)
                                if (data.Warehouse != 0)
                                    cities.Add(entry.Value, data.Description + ", " + data.AreaDescription);
                        break;
                    default:
                        foreach (var data in novaPoshta.Data)
                            if (cities.Count != 10)
                                if (data.Warehouse != 0)
                                    cities.Add(entry.Value, data.DescriptionRu + ", " + data.AreaDescriptionRu);
                        break;
                }
            }

            return cities;
        }

        public static async Task<Dictionary<Guid, string>> SendRequestToAPIAsync(string city)
        {
            return await Task.Run(() => GetCity(city)); ;
        }
    }
}