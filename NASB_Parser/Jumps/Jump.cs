using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class Jump
    {
        public TypeId Id { get; }
        public int Version { get; }

        public Jump()
        {
        }

        internal Jump(BulkSerializer reader)
        {
            Id = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        internal static Jump Read(BulkSerializer reader)
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