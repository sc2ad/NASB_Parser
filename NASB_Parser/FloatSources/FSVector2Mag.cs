using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSVector2Mag : FloatSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public FSVector2Mag()
        {
        }

        internal FSVector2Mag(BulkSerializeReader reader) : base(reader)
        {
            X = Read(reader);
            Y = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(X);
            writer.Write(Y);
        }
    }
}