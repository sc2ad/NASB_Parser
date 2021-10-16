using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public struct AnimConfig : ISerializable
    {
        public float Rate { get; set; }
        public float Weight { get; set; }
        public WrapMode Wrap { get; set; }
        public bool ClingToFrames { get; set; }

        public AnimConfig(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            Rate = reader.ReadFloat();
            Weight = reader.ReadFloat();
            Wrap = (WrapMode)reader.ReadInt();
            ClingToFrames = reader.ReadBool();
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(Rate);
            writer.Write(Weight);
            writer.Write(Wrap);
            writer.Write(ClingToFrames);
        }

        public enum WrapMode
        {
            Once = 1,
            Loop,
            PingPong = 4,
            Default = 0,
            ClampForever = 8,
            Clamp = 1
        }
    }
}