using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStateCancelGrabbed : StateAction
    {
        public string ToState { get; set; }
        public bool Proxy { get; set; }

        public SAStateCancelGrabbed()
        {
        }

        internal SAStateCancelGrabbed(BulkSerializeReader reader) : base(reader)
        {
            if (Version > 0)
            {
                Proxy = reader.ReadBool();
            }
            ToState = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Proxy);
            writer.Write(ToState);
        }
    }
}