using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSTimer : FloatSource
    {
        public string Id { get; set; }

        public FSTimer()
        {
        }

        internal FSTimer(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Id = reader.ReadString();
        }
    }
}