using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace TechnoTent.Models.InTimeAPI
{
    public class InTimeCity
    {
        static Dictionary<long, string> cities = new Dictionary<long, string>();

        static Dictionary<long, string> GetCity(string city)
        {
            Dictionary<long, string> RecievedCities = new Dictionary<long, string>();

            if (cities.Count() == 0)
            {
                string key = Admin.GetAdminData().InTimeKey;

                string json = @"{
                    ""Body"": {
                        ""api_key"": """ + key + @"""
                    }
                }";

                //отправка запроса
                var httpRequest = (HttpWebRequest)WebRequest.Create("https://ex.intime.ua:8443/intime_api_3.0/locality_all");
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
                //конец запроса

                InTimeCityModel name = InTimeCityModel.FromJson(response);

                var language = Cookies.Cookie.CheckLanguageCookie();

                switch (language)
                {
                    case "uk":
                        foreach (var data in name.EntriesGetLocalityAll.EntryGetLocalityAll)
                            cities.Add(data.Id, data.LocalityNameUa);
                        break;
                    case "en":
                        foreach (var data in name.EntriesGetLocalityAll.EntryGetLocalityAll)
                            cities.Add(data.Id, data.LocalityNameEn.String);
                        break;
                    default:
                        foreach (var data in name.EntriesGetLocalityAll.EntryGetLocalityAll)
                            cities.Add(data.Id, data.LocalityNameRu);
                        break;
                }

                RecievedCities = cities;
            }
            else
            {
                RecievedCities = cities;

                city = city.ToLower();

                var selectedCities = RecievedCities.Where(t => t.Value.ToLower().Contains(city)).ToDictionary(v => v.Key, v => v.Value);

                RecievedCities = selectedCities;
            }

            return RecievedCities;
        }

        public static async Task<Dictionary<long, string>> SendRequestToAPIAsync(string city)
        {
            return await Task.Run(() => GetCity(city)); ;
        }
    }
}