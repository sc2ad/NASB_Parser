using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class InputTrigger : ISerializable
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
            _ = reader.ReadInt();
            SniffFrames = reader.ReadInt();
            BlockedByEvent = (GIEV)reader.ReadInt();
            AddEventOnTrigger = (GIEV)reader.ReadInt();
            Action = StateAction.Read(reader);
            Validator = new InputValidator(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(SniffFrames);
            writer.Write(BlockedByEvent);
            writer.Write(AddEventOnTrigger);
            writer.Write(Action);
            writer.Write(Validator);
        }
    }
}