using NASB_Parser.ObjectSources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NASB_Parser.ObjectSources.ObjectSource;

namespace JsonDumper.Converters
{
    public class ObjectSourceConverter : JsonConverter<ObjectSource>
    {
        private static readonly PropertyInfo tidInfo = typeof(ObjectSource).GetProperty(nameof(ObjectSource.TID));
        private static readonly PropertyInfo versionInfo = typeof(ObjectSource).GetProperty(nameof(ObjectSource.Version));

        public override ObjectSource ReadJson(JsonReader reader, Type objectType, [AllowNull] ObjectSource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, ObjectSource>(reader, serializer, tidInfo, versionInfo, res => res switch
            {
                TypeId.FloatId => new OSFloat(),
                TypeId.Vector2Id => new OSVector2(),
                TypeId.BaseIdentifier => new ObjectSource(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ObjectSource value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo, versionInfo);
        }
    }
}