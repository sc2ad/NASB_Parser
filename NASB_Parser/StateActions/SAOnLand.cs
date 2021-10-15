using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOnLand : StateAction
    {
        public StateAction Action { get; set; }

        public SAOnLand()
        {
        }

        internal SAOnLand(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
        }
    }
}