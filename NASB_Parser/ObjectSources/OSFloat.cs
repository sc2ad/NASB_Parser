using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
    public class OSFloat : ObjectSource
    {
        public FloatSource Source { get; set; }

        public OSFloat()
        {
        }

        internal OSFloat(BulkSerializeReader reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Source);
        }
    }
}