using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAResetOnHits : StateAction
    {
        public SAResetOnHits()
        {
        }

        internal SAResetOnHits(BulkSerializer reader) : base(reader)
        {
        }
    }
}