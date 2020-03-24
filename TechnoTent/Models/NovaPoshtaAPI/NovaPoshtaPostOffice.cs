using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace TechnoTent.Models.NovaPoshtaAPI
{
    public class NovaPoshtaPostOffice
    {
        static List<string> GetPostOffices(string cityId)
        {
            string key = Admin.GetAdminData().NovaPoshtaKey;

            string json = @"{
                ""modelName"": ""AddressGeneral"",
                ""calledMethod"": ""getWarehouses"",
                ""methodProperties"": {
                            ""CityRef"": """ + cityId + @""",
                    ""Language"": ""ru""
                },
                ""apiKey"": """ + key + @"""
            }";

            var httpRequest = (HttpWebRequest)WebRequest.Create("http://api.novaposhta.ua/v2.0/json/AddressGeneral/getWarehouses");
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

            NovaPoshtaPostOfficeModel novaPoshta = NovaPoshtaPostOfficeModel.FromJson(response);

            List<string> cities = new List<string>();

            var language = Cookies.Cookie.CheckLanguageCookie();

            switch (language)
            {
                case "uk":
                    foreach (var data in novaPoshta.Data)
                        cities.Add(data.Description);
                    break;
                case "en":
                    foreach (var data in novaPoshta.Data)
                        cities.Add(data.Description);
                    break;
                default:
                    foreach (var data in novaPoshta.Data)
                        cities.Add(data.DescriptionRu);
                    break;
            }

            return cities;
        }

        public static async Task<List<string>> SendRequestToAPIAsync(string city)
        {
            return await Task.Run(() => GetPostOffices(city)); ;
        }
    }
}