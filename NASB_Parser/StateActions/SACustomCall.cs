using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACustomCall : StateAction
    {
        public string CallId { get; set; }

        public SACustomCall()
        {
        }

        internal SACustomCall(BulkSerializeReader reader) : base(reader)
        {
            CallId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CallId);
        }
    }
}