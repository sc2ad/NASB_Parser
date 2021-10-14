using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSRandom : FloatSource
    {
        public bool Ratio { get; set; }
        public FloatSource A { get; set; }
        public FloatSource B { get; set; }

        public FSRandom()
        {
        }

        internal FSRandom(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Ratio = reader.ReadInt() > 0;
            A = Read(reader);
            B = Read(reader);
        }
    }
}