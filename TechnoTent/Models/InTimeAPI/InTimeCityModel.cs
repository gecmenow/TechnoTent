using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.InTimeAPI
{
    public partial class InTimeCityModel
    {
        [JsonProperty("Entries_get_locality_all")]
        public EntriesGetLocalityAll EntriesGetLocalityAll { get; set; }
    }

    public partial class EntriesGetLocalityAll
    {
        [JsonProperty("Entry_get_locality_all")]
        public EntryGetLocalityAll[] EntryGetLocalityAll { get; set; }
    }

    public partial class EntryGetLocalityAll
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Area_Id")]
        public string AreaId { get; set; }

        [JsonProperty("Locality_Type_Id")]
        public long LocalityTypeId { get; set; }

        [JsonProperty("Locality_Name_Ua")]
        public string LocalityNameUa { get; set; }

        [JsonProperty("Locality_Name_En")]
        public LocalityNameEn LocalityNameEn { get; set; }

        [JsonProperty("Locality_Name_Ru")]
        public string LocalityNameRu { get; set; }

        [JsonProperty("Locality_Short_Name_Ua")]
        public string LocalityShortNameUa { get; set; }

        [JsonProperty("Locality_Short_Name_En")]
        public Index1 LocalityShortNameEn { get; set; }

        [JsonProperty("Locality_Short_Name_Ru")]
        public string LocalityShortNameRu { get; set; }

        [JsonProperty("Locality_Code")]
        public string LocalityCode { get; set; }

        [JsonProperty("Last_Change")]
        public DateTimeOffset LastChange { get; set; }

        [JsonProperty("Status")]
        public long Status { get; set; }

        [JsonProperty("District_Id")]
        public DistrictIdUnion DistrictId { get; set; }

        [JsonProperty("Latitude")]
        public Itude Latitude { get; set; }

        [JsonProperty("Longitude")]
        public Itude Longitude { get; set; }

        [JsonProperty("Koatuu")]
        public Index1 Koatuu { get; set; }

        [JsonProperty("Index_1")]
        public Index1 Index1 { get; set; }

        [JsonProperty("Index_2")]
        public Index2 Index2 { get; set; }
    }

    public partial class DistrictId
    {
        [JsonProperty("@nil")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool Nil { get; set; }
    }

    public partial struct DistrictIdUnion
    {
        public DistrictId DistrictId;
        public long? Integer;

        public static implicit operator DistrictIdUnion(DistrictId DistrictId) => new DistrictIdUnion { DistrictId = DistrictId };
        public static implicit operator DistrictIdUnion(long Integer) => new DistrictIdUnion { Integer = Integer };
    }

    public partial struct Index1
    {
        public DistrictId DistrictId;
        public long? Integer;
        public string String;

        public static implicit operator Index1(DistrictId DistrictId) => new Index1 { DistrictId = DistrictId };
        public static implicit operator Index1(long Integer) => new Index1 { Integer = Integer };
        public static implicit operator Index1(string String) => new Index1 { String = String };
    }

    public partial struct Index2
    {
        public DistrictId DistrictId;
        public double? Double;
        public string String;

        public static implicit operator Index2(DistrictId DistrictId) => new Index2 { DistrictId = DistrictId };
        public static implicit operator Index2(double Double) => new Index2 { Double = Double };
        public static implicit operator Index2(string String) => new Index2 { String = String };
    }

    public partial struct Itude
    {
        public DistrictId DistrictId;
        public double? Double;

        public static implicit operator Itude(DistrictId DistrictId) => new Itude { DistrictId = DistrictId };
        public static implicit operator Itude(double Double) => new Itude { Double = Double };
    }

    public partial struct LocalityNameEn
    {
        public DistrictId DistrictId;
        public string String;

        public static implicit operator LocalityNameEn(DistrictId DistrictId) => new LocalityNameEn { DistrictId = DistrictId };
        public static implicit operator LocalityNameEn(string String) => new LocalityNameEn { String = String };
    }

    public partial class InTimeCityModel
    {
        public static InTimeCityModel FromJson(string json) => JsonConvert.DeserializeObject<InTimeCityModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this InTimeCityModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DistrictIdUnionConverter.Singleton,
                Index1Converter.Singleton,
                Index2Converter.Singleton,
                ItudeConverter.Singleton,
                LocalityNameEnConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DistrictIdUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DistrictIdUnion) || t == typeof(DistrictIdUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new DistrictIdUnion { Integer = integerValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DistrictId>(reader);
                    return new DistrictIdUnion { DistrictId = objectValue };
            }
            throw new Exception("Cannot unmarshal type DistrictIdUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DistrictIdUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.DistrictId != null)
            {
                serializer.Serialize(writer, value.DistrictId);
                return;
            }
            throw new Exception("Cannot marshal type DistrictIdUnion");
        }

        public static readonly DistrictIdUnionConverter Singleton = new DistrictIdUnionConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class Index1Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Index1) || t == typeof(Index1?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Index1 { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Index1 { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DistrictId>(reader);
                    return new Index1 { DistrictId = objectValue };
            }
            throw new Exception("Cannot unmarshal type Index1");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Index1)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.DistrictId != null)
            {
                serializer.Serialize(writer, value.DistrictId);
                return;
            }
            throw new Exception("Cannot marshal type Index1");
        }

        public static readonly Index1Converter Singleton = new Index1Converter();
    }

    internal class Index2Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Index2) || t == typeof(Index2?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new Index2 { Double = doubleValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Index2 { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DistrictId>(reader);
                    return new Index2 { DistrictId = objectValue };
            }
            throw new Exception("Cannot unmarshal type Index2");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Index2)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.DistrictId != null)
            {
                serializer.Serialize(writer, value.DistrictId);
                return;
            }
            throw new Exception("Cannot marshal type Index2");
        }

        public static readonly Index2Converter Singleton = new Index2Converter();
    }

    internal class ItudeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Itude) || t == typeof(Itude?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new Itude { Double = doubleValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DistrictId>(reader);
                    return new Itude { DistrictId = objectValue };
            }
            throw new Exception("Cannot unmarshal type Itude");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Itude)untypedValue;
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.DistrictId != null)
            {
                serializer.Serialize(writer, value.DistrictId);
                return;
            }
            throw new Exception("Cannot marshal type Itude");
        }

        public static readonly ItudeConverter Singleton = new ItudeConverter();
    }

    internal class LocalityNameEnConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocalityNameEn) || t == typeof(LocalityNameEn?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new LocalityNameEn { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<DistrictId>(reader);
                    return new LocalityNameEn { DistrictId = objectValue };
            }
            throw new Exception("Cannot unmarshal type LocalityNameEn");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (LocalityNameEn)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.DistrictId != null)
            {
                serializer.Serialize(writer, value.DistrictId);
                return;
            }
            throw new Exception("Cannot marshal type LocalityNameEn");
        }

        public static readonly LocalityNameEnConverter Singleton = new LocalityNameEnConverter();
    }
}