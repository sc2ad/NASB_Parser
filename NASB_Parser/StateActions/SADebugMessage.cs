using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SADebugMessage : StateAction
    {
        public string Message { get; set; }

        public SADebugMessage()
        {
        }

        public SADebugMessage(BulkSerializeReader reader) : base(reader)
        {
            Message = reader.ReadString();
        }
    }
}