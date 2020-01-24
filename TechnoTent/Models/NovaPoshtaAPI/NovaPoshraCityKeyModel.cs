using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.NovaPoshtaAPI
{
    public partial class NovaPoshtaCityKeyModel
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
        public object[] Info { get; set; }

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
        [JsonProperty("TotalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("Addresses")]
        public Address[] Addresses { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("Present")]
        public string Present { get; set; }

        [JsonProperty("Warehouses")]
        public long Warehouses { get; set; }

        [JsonProperty("MainDescription")]
        public string MainDescription { get; set; }

        [JsonProperty("Area")]
        public string Area { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("SettlementTypeCode")]
        public string SettlementTypeCode { get; set; }

        [JsonProperty("Ref")]
        public Guid Ref { get; set; }

        [JsonProperty("DeliveryCity")]
        public Guid DeliveryCity { get; set; }

        [JsonProperty("StreetsAvailability")]
        public bool StreetsAvailability { get; set; }

        [JsonProperty("ParentRegionTypes")]
        public string ParentRegionTypes { get; set; }

        [JsonProperty("ParentRegionCode")]
        public string ParentRegionCode { get; set; }

        [JsonProperty("RegionTypes")]
        public string RegionTypes { get; set; }

        [JsonProperty("RegionTypesCode")]
        public string RegionTypesCode { get; set; }
    }

    public partial class NovaPoshtaCityKeyModel
    {
        public static NovaPoshtaCityKeyModel FromJson(string json) => JsonConvert.DeserializeObject<NovaPoshtaCityKeyModel>(json, Converter.Settings);
    }
}