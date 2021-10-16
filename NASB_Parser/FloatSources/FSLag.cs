using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSLag : FloatSource
    {
        public LagTypes LagType { get; set; }
        public ManipLags ManipLag { get; set; }

        public FSLag()
        {
        }

        internal FSLag(BulkSerializeReader reader) : base(reader)
        {
            LagType = (LagTypes)reader.ReadInt();
            ManipLag = (ManipLags)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(LagType);
            writer.Write(ManipLag);
        }

        public enum LagTypes
        {
            StateLag,
            MoveLag,
            Both
        }

        public enum ManipLags
        {
            Set,
            Add,
            Max
        }
    }
}