using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASB_Parser;
using Newtonsoft.Json;

namespace JsonDumper.Converters
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type objectType, [AllowNull] Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new JsonException();
            }
            Vector3 o = default;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return o;
                }
                var pName = reader.Value as string;
                if (pName == "x")
                {
                    o.x = (float)reader.ReadAsDouble();
                }
                else if (pName == "y")
                {
                    o.y = (float)reader.ReadAsDouble();
                }
                else if (pName == "z")
                {
                    o.z = (float)reader.ReadAsDouble();
                }
            }
            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);
            writer.WritePropertyName("z");
            writer.WriteValue(value.z);
            writer.WriteEndObject();
        }
    }
}