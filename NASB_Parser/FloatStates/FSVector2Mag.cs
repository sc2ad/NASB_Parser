using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSVector2Mag : FloatSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public FSVector2Mag()
        {
        }

        internal FSVector2Mag(BulkSerializer reader) : base(reader)
        {
            X = Read(reader);
            Y = Read(reader);
        }
    }
}