using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSFrame : FloatSource
    {
        public FSFrame()
        {
        }

        internal FSFrame(BulkSerializer reader) : base(reader)
        {
        }
    }
}