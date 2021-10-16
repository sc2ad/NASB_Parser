using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class HeightJump : Jump
    {
        public FloatSource Height { get; set; }

        public HeightJump()
        {
        }

        internal HeightJump(BulkSerializeReader reader) : base(reader)
        {
            Height = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Height);
        }
    }
}