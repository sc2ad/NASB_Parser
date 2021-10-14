using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAAddInputEventFromFrame : StateAction
    {
        public GIEV AddEvent { get; set; }

        public SAAddInputEventFromFrame()
        {
        }

        internal SAAddInputEventFromFrame(BulkSerializer reader) : base(reader)
        {
            AddEvent = (GIEV)reader.ReadInt();
        }
    }
}