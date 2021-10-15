using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSMode : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSMode()
        {
        }

        internal FSMode(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            InputAllowed
        }
    }
}