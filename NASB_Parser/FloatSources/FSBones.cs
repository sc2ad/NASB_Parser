using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSBones : FloatSource
    {
        public Attributes Attribute { get; set; }
        public string Bone { get; set; }

        public FSBones()
        { }

        internal FSBones(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
            if (Version > 0 && Attribute == Attributes.BoneActive)
            {
                Bone = reader.ReadString();
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
            if (Attribute == Attributes.BoneActive)
            {
                writer.Write(Bone);
            }
        }

        public enum Attributes
        {
            RotationAngle,
            LookAngle,
            TiltAngle,
            MirrorByDirection,
            OffsetX,
            OffsetY,
            BoneActive
        }
    }
}