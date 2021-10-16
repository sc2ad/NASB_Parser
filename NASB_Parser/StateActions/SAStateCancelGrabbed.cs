using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStateCancelGrabbed : StateAction
    {
        public string ToState { get; set; }

        public SAStateCancelGrabbed()
        {
        }

        internal SAStateCancelGrabbed(BulkSerializeReader reader) : base(reader)
        {
            ToState = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ToState);
        }
    }
}