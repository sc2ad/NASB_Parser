using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSColors : FloatSource
    {
        public string ColorId { get; set; }
        public bool Permanent { get; set; }

        public FSColors()
        {
        }

        internal FSColors(BulkSerializeReader reader) : base(reader)
        {
            ColorId = reader.ReadString();
            Permanent = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ColorId);
            writer.Write(Permanent);
        }
    }
}