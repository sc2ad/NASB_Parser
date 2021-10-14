using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSColors : FloatSource
    {
        public string ColorId { get; set; }
        public bool Permanent { get; set; }

        public FSColors()
        {
        }

        internal FSColors(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            ColorId = reader.ReadString();
            Permanent = reader.ReadInt() > 0;
        }
    }
}