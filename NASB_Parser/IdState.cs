using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class IdState
    {
        public string Id { get; set; }
        public List<string> Tags { get; }
        public AgentState State { get; set; }

        public IdState(BulkSerializer reader)
        {
            // Throwaway unused id
            _ = reader.ReadInt();
            Id = reader.ReadString();
            int sz = reader.ReadInt();
            Tags = new List<string>(sz);
            for (int i = 0; i < sz; i++)
            {
                Tags.Add(reader.ReadString());
            }
            State = AgentState.Read(reader);
        }
    }
}