using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.NovaPoshtaAPI
{
    public partial class NovaPoshtaCityModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("errors")]
        public object[] Errors { get; set; }

        [JsonProperty("warnings")]
        public object[] Warnings { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("messageCodes")]
        public object[] MessageCodes { get; set; }

        [JsonProperty("errorCodes")]
        public object[] ErrorCodes { get; set; }

        [JsonProperty("warningCodes")]
        public object[] WarningCodes { get; set; }

        [JsonProperty("infoCodes")]
        public object[] InfoCodes { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("SettlementType")]
        public Guid SettlementType { get; set; }

        [JsonProperty("SettlementTypeDescription")]
        public string SettlementTypeDescription { get; set; }

        [JsonProperty("SettlementTypeDescriptionRu")]
        public string SettlementTypeDescriptionRu { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("RegionsDescription")]
        public string RegionsDescription { get; set; }

        [JsonProperty("RegionsDescriptionRu")]
        public string RegionsDescriptionRu { get; set; }

        [JsonProperty("Area")]
        public Guid Area { get; set; }

        [JsonProperty("AreaDescription")]
        public string AreaDescription { get; set; }

        [JsonProperty("AreaDescriptionRu")]
        public string AreaDescriptionRu { get; set; }

        [JsonProperty("Index1")]
        public string Index1 { get; set; }

        [JsonProperty("Index2")]
        public string Index2 { get; set; }

        [JsonProperty("IndexCOATSU1")]
        public string IndexCoatsu1 { get; set; }

        [JsonProperty("Delivery1")]
        public string Delivery1 { get; set; }

        [JsonProperty("Delivery2")]
        public string Delivery2 { get; set; }

        [JsonProperty("Delivery3")]
        public string Delivery3 { get; set; }

        [JsonProperty("Delivery4")]
        public string Delivery4 { get; set; }

        [JsonProperty("Delivery5")]
        public string Delivery5 { get; set; }

        [JsonProperty("Delivery6")]
        public string Delivery6 { get; set; }

        [JsonProperty("Delivery7")]
        public string Delivery7 { get; set; }

        [JsonProperty("SpecialCashCheck")]
        public long SpecialCashCheck { get; set; }

        [JsonProperty("Warehouse")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Warehouse { get; set; }
    }

    public partial class Info
    {

    }

    public partial class NovaPoshtaCityModel
    {
        public static NovaPoshtaCityModel FromJson(string json) => JsonConvert.DeserializeObject<NovaPoshtaCityModel>(json, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}