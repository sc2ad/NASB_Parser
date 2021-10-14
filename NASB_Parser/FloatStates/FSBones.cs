using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSBones : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSBones()
        { }

        internal FSBones(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            RotationAngle,
            LookAngle,
            TiltAngle,
            MirrorByDirection,
            OffsetX,
            OffsetY
        }
    }
}