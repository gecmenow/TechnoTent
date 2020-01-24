using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.NovaPoshtaAPI
{
    public partial class NovaPoshtaPostOfficeModel
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
        [JsonProperty("SiteKey")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SiteKey { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DescriptionRu")]
        public string DescriptionRu { get; set; }

        [JsonProperty("ShortAddress")]
        public string ShortAddress { get; set; }

        [JsonProperty("ShortAddressRu")]
        public string ShortAddressRu { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("TypeOfWarehouse")]
        public Guid TypeOfWarehouse { get; set; }

        [JsonProperty("Ref")]
        public Guid Ref { get; set; }

        [JsonProperty("Number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Number { get; set; }

        [JsonProperty("CityRef")]
        public Guid CityRef { get; set; }

        [JsonProperty("CityDescription")]
        public string CityDescription { get; set; }

        [JsonProperty("CityDescriptionRu")]
        public string CityDescriptionRu { get; set; }

        [JsonProperty("Longitude")]
        public string Longitude { get; set; }

        [JsonProperty("Latitude")]
        public string Latitude { get; set; }

        [JsonProperty("PostFinance")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PostFinance { get; set; }

        [JsonProperty("BicycleParking")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BicycleParking { get; set; }

        [JsonProperty("PaymentAccess")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PaymentAccess { get; set; }

        [JsonProperty("POSTerminal")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PosTerminal { get; set; }

        [JsonProperty("InternationalShipping")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long InternationalShipping { get; set; }

        [JsonProperty("TotalMaxWeightAllowed")]
        [JsonConverter(typeof(DecodingChoiceConverter))]
        public long TotalMaxWeightAllowed { get; set; }

        [JsonProperty("PlaceMaxWeightAllowed")]
        [JsonConverter(typeof(DecodingChoiceConverter))]
        public long PlaceMaxWeightAllowed { get; set; }

        [JsonProperty("Reception")]
        public Delivery Reception { get; set; }

        [JsonProperty("Delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("Schedule")]
        public Delivery Schedule { get; set; }

        [JsonProperty("DistrictCode")]
        public string DistrictCode { get; set; }

        [JsonProperty("WarehouseStatus")]
        public string WarehouseStatus { get; set; }

        [JsonProperty("CategoryOfWarehouse")]
        public string CategoryOfWarehouse { get; set; }
    }

    public partial class Delivery
    {
        [JsonProperty("Monday")]
        public string Monday { get; set; }

        [JsonProperty("Tuesday")]
        public string Tuesday { get; set; }

        [JsonProperty("Wednesday")]
        public string Wednesday { get; set; }

        [JsonProperty("Thursday")]
        public string Thursday { get; set; }

        [JsonProperty("Friday")]
        public string Friday { get; set; }

        [JsonProperty("Saturday")]
        public string Saturday { get; set; }

        [JsonProperty("Sunday")]
        public string Sunday { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }

    public partial class NovaPoshtaPostOfficeModel
    {
        public static NovaPoshtaPostOfficeModel FromJson(string json) => JsonConvert.DeserializeObject<NovaPoshtaPostOfficeModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NovaPoshtaPostOfficeModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class DecodingChoiceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return integerValue;
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return l;
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value);
            return;
        }

        public static readonly DecodingChoiceConverter Singleton = new DecodingChoiceConverter();
    }
}