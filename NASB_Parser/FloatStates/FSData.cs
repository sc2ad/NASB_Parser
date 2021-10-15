using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSData : FloatSource
    {
        public string Id { get; set; }

        public FSData()
        {
        }

        internal FSData(BulkSerializer reader) : base(reader)
        {
            Id = reader.ReadString();
        }
    }
}