using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAUnHogEdge : StateAction
    {
        public SAUnHogEdge()
        {
        }

        internal SAUnHogEdge(BulkSerializer reader) : base(reader)
        {
        }
    }
}