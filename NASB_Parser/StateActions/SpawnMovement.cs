using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SpawnMovement
    {
        public string ToBone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public MovementConfig Config { get; set; }

        public SpawnMovement()
        {
        }

        internal SpawnMovement(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            ToBone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            Config = new MovementConfig(reader);
        }
    }
}