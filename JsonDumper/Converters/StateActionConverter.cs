using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonDumper.Converters
{
    public class StateActionConverter : JsonConverter<StateAction>
    {
        public override StateAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, StateAction value, JsonSerializerOptions options)
        {
            if (value.GetType() == typeof(StateAction))
            {
                // Empty StateAction is an empty StateAction, don't recurse forever.
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