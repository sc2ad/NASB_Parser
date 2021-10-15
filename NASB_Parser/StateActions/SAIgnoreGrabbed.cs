using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAIgnoreGrabbed : StateAction
    {
        public SAIgnoreGrabbed()
        {
        }

        internal SAIgnoreGrabbed(BulkSerializer reader) : base(reader)
        {
        }
    }
}