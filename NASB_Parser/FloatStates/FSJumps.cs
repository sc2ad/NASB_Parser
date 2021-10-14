using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSJumps : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSJumps()
        {
        }

        internal FSJumps(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            TotalAirJumpsLeft,
            TotalAirDashesLeft
        }
    }
}