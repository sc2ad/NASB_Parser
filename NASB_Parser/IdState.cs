using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class IdState
    {
        public string Id { get; set; }
        public List<string> Tags { get; } = new List<string>();
        public AgentState State { get; set; }

        public IdState()
        {
        }

        internal IdState(BulkSerializeReader reader)
        {
            // Throwaway unused id
            _ = reader.ReadInt();
            Id = reader.ReadString();
            Tags = reader.ReadList(r => r.ReadString());
            State = AgentState.Read(reader);
        }
    }
}