using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetCommandGrab : StateAction
    {
        public string State { get; set; }

        public SASetCommandGrab()
        {
        }

        internal SASetCommandGrab(BulkSerializeReader reader) : base(reader)
        {
            State = reader.ReadString();
        }
    }
}