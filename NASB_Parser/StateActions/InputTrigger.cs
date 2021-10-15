using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class InputTrigger
    {
        public int SniffFrames { get; set; }
        public GIEV BlockedByEvent { get; set; }
        public GIEV AddEventOnTrigger { get; set; }
        public StateAction Action { get; set; }
        public InputValidator Validator { get; set; }

        public InputTrigger()
        {
        }

        public InputTrigger(BulkSerializeReader reader)
        {
            reader.ReadInt();
            SniffFrames = reader.ReadInt();
            BlockedByEvent = (GIEV)reader.ReadInt();
            AddEventOnTrigger = (GIEV)reader.ReadInt();
            Action = StateAction.Read(reader);
            Validator = new InputValidator(reader);
        }
    }
}