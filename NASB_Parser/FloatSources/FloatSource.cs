using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public abstract class FloatSource : ISerializable
    {
        public TypeId TID { get; }
        public int Version { get; }

        public FloatSource()
        {
        }

        internal FloatSource(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static FloatSource Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.AgentId => new FSAgent(reader),
                TypeId.BonesId => new FSBones(reader),
                TypeId.AttackId => new FSAttack(reader),
                TypeId.FrameId => new FSFrame(reader),
                TypeId.InputId => new FSInput(reader),
                TypeId.FuncId => new FSFunc(reader),
                TypeId.MovementId => new FSMovement(reader),
                TypeId.CombatId => new FSCombat(reader),
                TypeId.GrabsId => new FSGrabs(reader),
                TypeId.DataId => new FSData(reader),
                TypeId.ScratchId => new FSScratch(reader),
                TypeId.AnimId => new FSAnim(reader),
                TypeId.SpeedId => new FSSpeed(reader),
                TypeId.PhysicsId => new FSPhysics(reader),
                TypeId.CollisionId => new FSCollision(reader),
                TypeId.TimerId => new FSTimer(reader),
                TypeId.LagId => new FSLag(reader),
                TypeId.EffectsId => new FSEffects(reader),
                TypeId.ColorsId => new FSColors(reader),
                TypeId.OnHitId => new FSOnHit(reader),
                TypeId.RandomId => new FSRandom(reader),
                TypeId.CameraId => new FSCameraInfo(reader),
                TypeId.SportsId => new FSSports(reader),
                TypeId.Vector2Mag => new FSVector2Mag(reader),
                TypeId.CPUHelpId => new FSCpuHelp(reader),
                TypeId.ItemId => new FSItem(reader),
                TypeId.ModeId => new FSMode(reader),
                TypeId.JumpsId => new FSJumps(reader),
                TypeId.RootAnimId => new FSRootAnim(reader),
                TypeId.FloatId => new FSValue(reader),
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(FloatSource)} type from: {reader.PeekInt()}!"),
            };
        }

        public enum TypeId
        {
            FloatId,
            AgentId,
            BonesId,
            AttackId,
            FrameId,
            InputId,
            FuncId,
            MovementId,
            CombatId,
            GrabsId,
            DataId,
            ScratchId,
            AnimId,
            SpeedId,
            PhysicsId,
            CollisionId,
            TimerId,
            LagId,
            EffectsId,
            ColorsId,
            OnHitId,
            RandomId,
            CameraId,
            SportsId,
            Vector2Mag,
            CPUHelpId,
            ItemId,
            ModeId,
            JumpsId,
            RootAnimId
        }
    }
}