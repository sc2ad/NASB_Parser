using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class AgentState
    {
        public string CustomCall { get; set; }
        public List<TimedAction> Timeline { get; }

        public AgentState()
        {
            Timeline = new List<TimedAction>();
        }

        internal static AgentState Read(BulkSerializer reader)
        {
            int tid = reader.ReadInt();
            if (tid != 0)
                throw new ReadException(reader, $"Cannot read an AgentState from tid: {tid}");
            return new AgentState(reader);
        }

        private AgentState(BulkSerializer reader)
        {
            reader.ReadInt();
            CustomCall = reader.ReadString();
            int cnt = reader.ReadInt();
            Timeline = new List<TimedAction>(cnt);
            for (int i = 0; i < cnt; i++)
            {
                Timeline.Add(new TimedAction(reader));
            }
        }
    }
}