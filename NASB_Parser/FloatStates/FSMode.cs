using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSMode : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSMode()
        {
        }

        internal FSMode(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            InputAllowed
        }
    }
}