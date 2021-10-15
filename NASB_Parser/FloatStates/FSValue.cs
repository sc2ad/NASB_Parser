using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
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

        internal FSValue(BulkSerializer reader) : base(reader)
        {
            Value = reader.ReadFloat();
        }
    }
}