using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace TechnoTent.Models.InTimeAPI
{
    public class InTimePostOffice
    {
        static List<string> GetPostOffices(string cityId)
        {
            string key = Admin.GetAdminData().InTimeKey;

            string json = @"{
                ""Body"": {
                    ""api_key"": """ + key + @""",
                    ""locality_id"": """ + cityId + @"""
                }
            }";

            var httpRequest = (HttpWebRequest)WebRequest.Create("https://ex.intime.ua:8443/intime_api_3.0/branch_filtered");
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

            List<string> cities = new List<string>();

            var language = Cookies.Cookie.CheckLanguageCookie();

            if (InTimeGetOnePostOffice.CheckPostOfficesCount(response) == 1)
            {
                List<InTimeGetOnePostOffice> offices = InTimeGetOnePostOffice.GetSinglePostOffice(response);

                switch (language)
                {
                    case "uk":
                        foreach (var data in offices)
                            cities.Add(data.BranchNameUa + " - " + data.AddressUa);
                        break;
                    case "en":
                        foreach (var data in offices)
                            cities.Add(data.BranchNameUa + " - " + data.AddressUa);
                        break;
                    default:
                        foreach (var data in offices)
                            cities.Add(data.BranchNameRu + " - " + data.AddressRu);
                        break;
                }
            }
            else
            {
                InTimePostOfficeModel inTime = InTimePostOfficeModel.FromJson(response);

                switch (language)
                {
                    case "uk":
                        foreach (var data in inTime.EntriesGetBranchFiltered.EntryGetBranchFiltered)
                            cities.Add(data.BranchNameUa + " - " + data.AddressUa);
                        break;
                    case "en":
                        foreach (var data in inTime.EntriesGetBranchFiltered.EntryGetBranchFiltered)
                            cities.Add(data.BranchNameEn.String + " - " + data.AddressEn.String);
                        break;
                    default:
                        foreach (var data in inTime.EntriesGetBranchFiltered.EntryGetBranchFiltered)
                            cities.Add(data.BranchNameRu + " - " + data.AddressRu);
                        break;
                }
            }

            return cities;
        }

        public static async Task<List<string>> SendRequestToAPIAsync(string cityId)
        {
            return await Task.Run(() => GetPostOffices(cityId)); ;
        }
    }
}