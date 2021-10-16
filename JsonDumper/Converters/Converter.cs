using NASB_Parser.StateActions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonDumper.Converters
{
    public static class Converter
    {
        internal static U ReadJson<T, U>(JsonReader reader, JsonSerializer serializer, PropertyInfo tidInfo, PropertyInfo versionInfo, Func<T, U> creator) where T : struct
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonException();
            reader.Read();
            var typeIdName = reader.Value as string;
            if (typeIdName != tidInfo.Name)
                throw new JsonException();
            if (!Enum.TryParse<T>(reader.ReadAsString(), false, out var res))
                throw new JsonException();
            var outp = creator(res);
            tidInfo.SetValue(outp, res);
            var props = outp.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            reader.Read();
            var ver = reader.ReadAsInt32();
            versionInfo.SetValue(outp, ver);
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    return outp;
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var pName = reader.Value as string;
                    reader.Read();
                    var match = props.FirstOrDefault(p => p.Name == pName);
                    if (match != null)
                    {
                        match.SetValue(outp, serializer.Deserialize(reader, match.PropertyType));
                    }
                    else
                    {
                        throw new JsonException();
                    }
                }
            }
            throw new JsonException();
        }

        internal static void WriteJson<T>(JsonWriter writer, [AllowNull] T value, JsonSerializer serializer, PropertyInfo tidInfo, PropertyInfo versionInfo)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(tidInfo.Name);
            writer.WriteValue(tidInfo.GetValue(value).ToString());
            writer.WritePropertyName(versionInfo.Name);
            writer.WriteValue(versionInfo.GetValue(value));
            if (value.GetType() == typeof(StateAction))
            {
                // Empty is empty, don't recurse forever.
                writer.WriteEndObject();
            }
            else
            {
                foreach (var p in value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (p.Name == tidInfo.Name || p.Name == versionInfo.Name)
                        continue;
                    writer.WritePropertyName(p.Name);
                    serializer.Serialize(writer, p.GetValue(value), p.PropertyType);
                }
                writer.WriteEndObject();
            }
        }
    }
}