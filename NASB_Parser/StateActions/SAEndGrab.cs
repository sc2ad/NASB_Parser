using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAEndGrab : StateAction
    {
        public SAEndGrab()
        {
        }

        internal SAEndGrab(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}