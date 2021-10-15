using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonDumper.Converters
{
    public class FloatSourceConverter : JsonConverter<FloatSource>
    {
        public override FloatSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, FloatSource value, JsonSerializerOptions options)
        {
            if (value.GetType() == typeof(FloatSource))
            {
                throw new InvalidOperationException("Should not ever have an instance of a FloatSource!");
            }
            else
            {
                JsonSerializer.Serialize<object>(writer, value, options);
            }
        }
    }
}