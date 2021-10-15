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

        internal SAUnHogEdge(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}