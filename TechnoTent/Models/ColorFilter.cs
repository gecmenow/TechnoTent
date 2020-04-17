using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models
{
    public class ColorFilter
    {
        public static string ChangeColorNameForFilter(string color)
        {
            color = color.Replace(" ", "_");

            return color;
        }

        public static string ChangeColorNameFromFilter(string color)
        {
            color = color.Replace("_", " ");

            return color;
        }
    }
}