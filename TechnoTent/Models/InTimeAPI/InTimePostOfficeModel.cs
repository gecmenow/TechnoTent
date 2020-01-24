using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnoTent.Models.InTimeAPI
{
    public partial class InTimePostOfficeModel
    {
        [JsonProperty("Entries_get_branch_filtered")]
        public EntriesGetBranchFiltered EntriesGetBranchFiltered { get; set; }
    }

    public partial class EntriesGetBranchFiltered
    {
        [JsonProperty("Entry_get_branch_filtered")]
        public EntryGetBranchFiltered[] EntryGetBranchFiltered { get; set; }
    }

    public partial class EntryGetBranchFiltered
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parent_id")]
        public long ParentId { get; set; }

        [JsonProperty("branch_type_id")]
        public long BranchTypeId { get; set; }

        [JsonProperty("branch_number")]
        public long BranchNumber { get; set; }

        [JsonProperty("branch_name_ua")]
        public string BranchNameUa { get; set; }

        [JsonProperty("branch_name_en")]
        public AddressEnUnion BranchNameEn { get; set; }

        [JsonProperty("branch_name_ru")]
        public string BranchNameRu { get; set; }

        [JsonProperty("branch_short_name_ua")]
        public string BranchShortNameUa { get; set; }

        [JsonProperty("branch_short_name_en")]
        public AddressEnUnion BranchShortNameEn { get; set; }

        [JsonProperty("branch_short_name_ru")]
        public string BranchShortNameRu { get; set; }

        [JsonProperty("locality_id")]
        public long LocalityId { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("address_ua")]
        public string AddressUa { get; set; }

        [JsonProperty("address_en")]
        public AddressEnUnion AddressEn { get; set; }

        [JsonProperty("address_ru")]
        public string AddressRu { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("last_change")]
        public DateTimeOffset LastChange { get; set; }
    }

    public partial class PurpleEn
    {
        [JsonProperty("@nil")]
        public Nil Nil { get; set; }
    }

    public partial struct Nil
    {
        public bool? Bool;
        public long? Integer;

        public static implicit operator Nil(bool Bool) => new Nil { Bool = Bool };
        public static implicit operator Nil(long Integer) => new Nil { Integer = Integer };
    }

    public partial struct AddressEnUnion
    {
        public PurpleEn PurpleEn;
        public string String;

        public static implicit operator AddressEnUnion(PurpleEn PurpleEn) => new AddressEnUnion { PurpleEn = PurpleEn };
        public static implicit operator AddressEnUnion(string String) => new AddressEnUnion { String = String };
    }

    public partial class InTimePostOfficeModel
    {
        public static InTimePostOfficeModel FromJson(string json) => JsonConvert.DeserializeObject<InTimePostOfficeModel>(json, Converter.Settings);
    }

    internal class AddressEnUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AddressEnUnion) || t == typeof(AddressEnUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new AddressEnUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleEn>(reader);
                    return new AddressEnUnion { PurpleEn = objectValue };
            }
            throw new Exception("Cannot unmarshal type AddressEnUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (AddressEnUnion)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.PurpleEn != null)
            {
                serializer.Serialize(writer, value.PurpleEn);
                return;
            }
            throw new Exception("Cannot marshal type AddressEnUnion");
        }

        public static readonly AddressEnUnionConverter Singleton = new AddressEnUnionConverter();
    }

    internal class NilConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Nil) || t == typeof(Nil?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    bool b;
                    if (Boolean.TryParse(stringValue, out b))
                    {
                        return new Nil { Bool = b };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new Nil { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type Nil");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Nil)untypedValue;
            if (value.Bool != null)
            {
                var boolString = value.Bool.Value ? "true" : "false";
                serializer.Serialize(writer, boolString);
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type Nil");
        }

        public static readonly NilConverter Singleton = new NilConverter();
    }
}