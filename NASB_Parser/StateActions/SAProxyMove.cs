using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAProxyMove : StateAction
    {
        public string MoveId { get; set; }

        public SAProxyMove()
        {
        }

        internal SAProxyMove(BulkSerializeReader reader) : base(reader)
        {
            MoveId = reader.ReadString();
        }
    }
}