using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSRandom : FloatSource
    {
        public bool Ratio { get; set; }
        public FloatSource A { get; set; }
        public FloatSource B { get; set; }

        public FSRandom()
        {
        }

        internal FSRandom(BulkSerializeReader reader) : base(reader)
        {
            Ratio = reader.ReadBool();
            A = Read(reader);
            B = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Ratio);
            writer.Write(A);
            writer.Write(B);
        }
    }
}