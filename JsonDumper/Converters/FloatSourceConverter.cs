using NASB_Parser.FloatSources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NASB_Parser.FloatSources.FloatSource;

namespace JsonDumper.Converters
{
    public class FloatSourceConverter : JsonConverter<FloatSource>
    {
        private static readonly PropertyInfo tidInfo = typeof(FloatSource).GetProperty(nameof(FloatSource.TID));
        private static readonly PropertyInfo versionInfo = typeof(FloatSource).GetProperty(nameof(FloatSource.Version));

        public override FloatSource ReadJson(JsonReader reader, Type objectType, [AllowNull] FloatSource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, FloatSource>(reader, serializer, tidInfo, versionInfo, res => res switch
            {
                TypeId.AgentId => new FSAgent(),
                TypeId.BonesId => new FSBones(),
                TypeId.AttackId => new FSAttack(),
                TypeId.FrameId => new FSFrame(),
                TypeId.InputId => new FSInput(),
                TypeId.FuncId => new FSFunc(),
                TypeId.MovementId => new FSMovement(),
                TypeId.CombatId => new FSCombat(),
                TypeId.GrabsId => new FSGrabs(),
                TypeId.DataId => new FSData(),
                TypeId.ScratchId => new FSScratch(),
                TypeId.AnimId => new FSAnim(),
                TypeId.SpeedId => new FSSpeed(),
                TypeId.PhysicsId => new FSPhysics(),
                TypeId.CollisionId => new FSCollision(),
                TypeId.TimerId => new FSTimer(),
                TypeId.LagId => new FSLag(),
                TypeId.EffectsId => new FSEffects(),
                TypeId.ColorsId => new FSColors(),
                TypeId.OnHitId => new FSOnHit(),
                TypeId.RandomId => new FSRandom(),
                TypeId.CameraId => new FSCameraInfo(),
                TypeId.SportsId => new FSSports(),
                TypeId.Vector2Mag => new FSVector2Mag(),
                TypeId.CPUHelpId => new FSCpuHelp(),
                TypeId.ItemId => new FSItem(),
                TypeId.ModeId => new FSMode(),
                TypeId.JumpsId => new FSJumps(),
                TypeId.RootAnimId => new FSRootAnim(),
                TypeId.FloatId => new FSValue(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] FloatSource value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo, versionInfo);
        }
    }
}