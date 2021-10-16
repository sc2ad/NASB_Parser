using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class Jump : ISerializable
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public Jump()
        {
        }

        internal Jump(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        internal static Jump Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.HeightId => new HeightJump(reader),
                TypeId.HoldId => new HoldJump(reader),
                TypeId.AirdashId => new AirDashJump(reader),
                TypeId.KnockbackId => new KnockbackJump(reader),
                TypeId.BaseIdentifier => new Jump(reader),
                // This is more aggressive than the game parser for better error detection.
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(Jump)} type from: {reader.PeekInt()}!"),
            };
        }

        public enum TypeId
        {
            BaseIdentifier,
            HeightId,
            HoldId,
            AirdashId,
            KnockbackId
        }
    }
}