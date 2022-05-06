using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStateCancelGrabbed : StateAction
    {
        public string ToState { get; set; }
        public bool Proxy;

        public SAStateCancelGrabbed()
        {
        }

        internal SAStateCancelGrabbed(BulkSerializeReader reader) : base(reader)
        {
            ToState = reader.ReadString();
            Proxy = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ToState);
            writer.Write(Proxy);
        }
    }
}