using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAInputAction : StateAction
    {
        public float Frames { get; set; }
        public string Id { get; set; }
        public InputTrigger Trigger { get; set; }

        public SAInputAction()
        {
        }

        internal SAInputAction(BulkSerializer reader) : base(reader)
        {
            Frames = reader.ReadFloat();
            Id = reader.ReadString();
            Trigger = new InputTrigger(reader);
        }
    }
}