using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SABoneScale : StateAction
    {
        public string Bone { get; set; }
        public FloatSource Source { get; set; }

        public SABoneScale()
        {
        }

        internal SABoneScale(BulkSerializeReader reader) : base(reader)
        {
            Bone = reader.ReadString();
            Source = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Bone);
            writer.Write(Source);
        }
    }
}