using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOnStoppedAtLedge : StateAction
    {
        public StateAction Action { get; set; }

        public SAOnStoppedAtLedge()
        {
        }

        internal SAOnStoppedAtLedge(BulkSerializer reader) : base(reader)
        {
            Action = Read(reader);
        }
    }
}