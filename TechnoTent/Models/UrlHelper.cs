using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TechnoTent.Models
{
    public class UrlHelper
    {
        public static string GenerateSeoFriendlyURL(string Title)
        {
            if (Title != null)
            {
                Regex regex = new Regex(@"[^a-zA-Z0-9-\s]", (RegexOptions)0);

                Title = regex.Replace(Title, "");
                Title = Title.ToLower().Replace(" - ", "-");
                Title = Title.ToLower().Replace("- ", "-");
                Title = Title.ToLower().Replace(" -", "-");
                Title = Title.ToLower().Replace("   ", " ");
                Title = Title.ToLower().Replace("  ", " ");
                Title = Title.ToLower().Replace("  ", " ");
                Title = Title.ToLower().Replace(" ", " ");
                Title = Title.ToLower().Replace(" ", "-");
                Title = Title.ToLower().Replace(" ", "-");

                return Title;
            }
            else
                return Title;
        }

        public static string SeoFriendlyUlrToString(string url)
        {
            url = url.ToLower().Replace("-", " ");

            return url;
        }
    }
}