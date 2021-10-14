using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSAgent : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSAgent()
        {
        }

        internal FSAgent(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            DestroyAfterFrame,
            PlayerIndex,
            Attackteam,
            Defendteam,
            PleaseRespawn,
            Gameteam,
            OrderAdded
        }
    }
}