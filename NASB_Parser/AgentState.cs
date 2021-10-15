using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class AgentState : ISerializable
    {
        public string CustomCall { get; set; }
        public List<TimedAction> Timeline { get; } = new List<TimedAction>();

        public AgentState()
        {
        }

        internal static AgentState Read(BulkSerializeReader reader)
        {
            int tid = reader.ReadInt();
            if (tid != 0)
                throw new ReadException(reader, $"Cannot read an AgentState from tid: {tid}");
            return new AgentState(reader);
        }

        private AgentState(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            CustomCall = reader.ReadString();
            Timeline = reader.ReadList(r => new TimedAction(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(CustomCall);
            writer.Write(Timeline);
        }
    }
}