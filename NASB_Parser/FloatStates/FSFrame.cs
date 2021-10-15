using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSFrame : FSValue
    {
        public FSFrame()
        {
        }

        public FSFrame(float x) : base(x)
        {
        }

        internal FSFrame(BulkSerializer reader) : base(reader)
        {
        }
    }
}