using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSJumps : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSJumps()
        {
        }

        internal FSJumps(BulkSerializer reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            TotalAirJumpsLeft,
            TotalAirDashesLeft
        }
    }
}