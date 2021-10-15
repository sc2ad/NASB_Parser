using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SALaunchGrabbed : StateAction
    {
        public string AtkProp { get; set; }

        public SALaunchGrabbed()
        {
        }

        internal SALaunchGrabbed(BulkSerializer reader) : base(reader)
        {
            AtkProp = reader.ReadString();
        }
    }
}