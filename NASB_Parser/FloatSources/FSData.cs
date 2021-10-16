using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSData : FloatSource
    {
        public string Id { get; set; }

        public FSData()
        {
        }

        internal FSData(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
        }
    }
}