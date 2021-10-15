using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAHurtGrabbed : StateAction
    {
        public string AtkProp { get; set; }

        public SAHurtGrabbed()
        {
        }

        internal SAHurtGrabbed(BulkSerializeReader reader) : base(reader)
        {
            AtkProp = reader.ReadString();
        }
    }
}