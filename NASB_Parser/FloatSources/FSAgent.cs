using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSAgent : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSAgent()
        {
        }

        internal FSAgent(BulkSerializeReader reader) : base(reader)
        {
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