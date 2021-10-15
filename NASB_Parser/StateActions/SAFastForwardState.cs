using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFastForwardState : StateAction
    {
        public FloatSource Frames { get; set; }

        public SAFastForwardState()
        {
        }

        internal SAFastForwardState(BulkSerializer reader) : base(reader)
        {
            Frames = FloatSource.Read(reader);
        }
    }
}