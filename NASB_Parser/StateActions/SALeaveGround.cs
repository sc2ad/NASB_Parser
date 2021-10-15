using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SALeaveGround : StateAction
    {
        public SALeaveGround()
        {
        }

        internal SALeaveGround(BulkSerializer reader) : base(reader)
        {
        }
    }
}