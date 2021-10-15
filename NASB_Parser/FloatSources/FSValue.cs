using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSValue : FloatSource
    {
        public float Value { get; set; }

        public FSValue()
        {
        }

        public FSValue(float x)
        {
            Value = x;
        }

        internal FSValue(BulkSerializeReader reader) : base(reader)
        {
            Value = reader.ReadFloat();
        }
    }
}