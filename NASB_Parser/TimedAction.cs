using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class TimedAction : ISerializable
    {
        public float AtFrame { get; set; }
        public StateAction Action { get; set; }

        public TimedAction() { }

        internal TimedAction(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            AtFrame = reader.ReadFloat();
            Action = StateAction.Read(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(AtFrame);
            writer.Write(Action);
        }
    }
}