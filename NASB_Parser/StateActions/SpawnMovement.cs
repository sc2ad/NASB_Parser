using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SpawnMovement : ISerializable
    {
        public string ToBone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public MovementConfig Config { get; set; }

        public SpawnMovement()
        {
        }

        internal SpawnMovement(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            ToBone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            Config = new MovementConfig(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(ToBone);
            writer.Write(LocalOffset);
            writer.Write(WorldOffset);
            writer.Write(Config);
        }
    }
}