using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASpawnAgent : StateAction
    {
        public string Bank { get; set; }
        public string Id { get; set; }
        public string Bone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public SAGUAMessageObject MessageObject { get; set; }
        public bool CustomSpawnMovement { get; set; }
        public List<SpawnMovement> Movements { get; } = new List<SpawnMovement>();
        public FloatSource ResultOrderAdded { get; set; }

        public SASpawnAgent()
        {
        }

        internal SASpawnAgent(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            bool hasResult = reader.ReadBool();
            Bank = reader.ReadString();
            Id = reader.ReadString();
            Bone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            MessageObject = new SAGUAMessageObject(reader);
            CustomSpawnMovement = reader.ReadBool();
            Movements = reader.ReadList(r => new SpawnMovement(r));
            if (hasResult)
            {
                ResultOrderAdded = FloatSource.Read(reader);
            }
        }
    }
}