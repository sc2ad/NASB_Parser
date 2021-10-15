using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOnLeaveEdge : StateAction
    {
        public StateAction Action { get; set; }

        public SAOnLeaveEdge()
        {
        }

        internal SAOnLeaveEdge(BulkSerializer reader) : base(reader)
        {
            Action = Read(reader);
        }
    }
}