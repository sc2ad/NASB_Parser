using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAForceExtraInputCheck : StateAction
    {
        public SAForceExtraInputCheck()
        {
        }

        internal SAForceExtraInputCheck(BulkSerializer reader) : base(reader)
        {
        }
    }
}