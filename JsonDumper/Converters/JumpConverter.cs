using NASB_Parser.Jumps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NASB_Parser.Jumps.Jump;

namespace JsonDumper.Converters
{
    public class JumpConverter : JsonConverter<Jump>
    {
        private static readonly PropertyInfo tidInfo = typeof(Jump).GetProperty(nameof(Jump.TID));
        private static readonly PropertyInfo versionInfo = typeof(Jump).GetProperty(nameof(Jump.Version));

        public override Jump ReadJson(JsonReader reader, Type objectType, [AllowNull] Jump existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, Jump>(reader, serializer, tidInfo, versionInfo, res => res switch
            {
                TypeId.HeightId => new HeightJump(),
                TypeId.HoldId => new HoldJump(),
                TypeId.AirdashId => new AirDashJump(),
                TypeId.KnockbackId => new KnockbackJump(),
                TypeId.DelayedId => new DelayedJump(),
                TypeId.ClampMomentumId => new ClampMomentumJump(),
                TypeId.BaseIdentifier => new Jump(),
                // This is more aggressive than the game parser for better error detection.
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] Jump value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo, versionInfo);
        }
    }
}