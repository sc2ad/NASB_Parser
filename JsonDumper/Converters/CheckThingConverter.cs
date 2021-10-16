using NASB_Parser.CheckThings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NASB_Parser.CheckThings.CheckThing;

namespace JsonDumper.Converters
{
    public class CheckThingConverter : JsonConverter<CheckThing>
    {
        private static readonly PropertyInfo tidInfo = typeof(CheckThing).GetProperty(nameof(CheckThing.TID));
        private static readonly PropertyInfo versionInfo = typeof(CheckThing).GetProperty(nameof(CheckThing.Version));

        public override CheckThing ReadJson(JsonReader reader, Type objectType, [AllowNull] CheckThing existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, CheckThing>(reader, serializer, tidInfo, versionInfo, res => res switch
            {
                TypeId.MultipleId => new CTMultiple(),
                TypeId.CompareId => new CTCompareFloat(),
                TypeId.DoubleTapId => new CTDoubleTapId(),
                TypeId.InputId => new CTInput(),
                TypeId.InputSeriesId => new CTInputSeries(),
                TypeId.TechId => new CTCheckTech(),
                TypeId.GrabId => new CTGrabId(),
                TypeId.GrabAgentId => new CTGrabbedAgent(),
                TypeId.SkinId => new CTSkin(),
                TypeId.MoveId => new CTMove(),
                TypeId.BaseIdentifier => new CheckThing(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] CheckThing value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo, versionInfo);
        }
    }
}