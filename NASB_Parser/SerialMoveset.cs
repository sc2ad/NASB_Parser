using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class SerialMoveset
    {
        public List<IdState> States { get; } = new List<IdState>();

        public SerialMoveset(BulkSerializer reader)
        {
            reader.Reset();
            _ = reader.ReadInt();
            States = reader.ReadList(r => new IdState(r));
        }
    }
}