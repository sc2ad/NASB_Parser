using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSTimer : FloatSource
    {
        public string Id { get; set; }

        public FSTimer()
        {
        }

        internal FSTimer(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }
    }
}