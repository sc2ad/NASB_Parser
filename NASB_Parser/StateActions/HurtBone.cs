using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class HurtBone : ISerializable
    {
        public HurtType Type { get; set; }
        public int Armor { get; set; }
        public int KnockbackArmor { get; set; }
        public bool IgnoreGrab { get; set; }
        public string BoneA { get; set; }
        public string BoneB { get; set; }
        public float Radius { get; set; }
        public Vector3 LocalOffsetA { get; set; }
        public Vector3 WorldOffsetA { get; set; }
        public Vector3 LocalOffsetB { get; set; }
        public Vector3 WorldOffsetB { get; set; }

        public HurtBone()
        {
        }

        internal HurtBone(BulkSerializeReader reader)
        {
            int version = reader.ReadInt();
            Type = (HurtType)reader.ReadInt();
            Armor = reader.ReadInt();
            if (version > 0)
            {
                KnockbackArmor = reader.ReadInt();
            }
            IgnoreGrab = reader.ReadBool();
            BoneA = reader.ReadString();
            BoneB = reader.ReadString();
            Radius = reader.ReadFloat();
            LocalOffsetA = reader.ReadVector3();
            WorldOffsetA = reader.ReadVector3();
            LocalOffsetB = reader.ReadVector3();
            WorldOffsetB = reader.ReadVector3();
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(1);
            writer.Write(Type);
            writer.Write(Armor);
            writer.Write(KnockbackArmor);
            writer.Write(IgnoreGrab);
            writer.Write(BoneA);
            writer.Write(BoneB);
            writer.Write(Radius);
            writer.Write(LocalOffsetA);
            writer.Write(WorldOffsetA);
            writer.Write(LocalOffsetB);
            writer.Write(WorldOffsetB);
        }
    }
}