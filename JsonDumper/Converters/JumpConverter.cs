using NASB_Parser.Jumps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonDumper.Converters
{
    public class JumpConverter : JsonConverter<Jump>
    {
        public override Jump Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Jump value, JsonSerializerOptions options)
        {
            if (value.GetType() == typeof(Jump))
            {
                // Empty is empty, don't recurse forever.
                writer.WriteStartObject();
                writer.WriteEndObject();
            }
            else
            {
                JsonSerializer.Serialize<object>(writer, value, options);
            }
        }
    }
}