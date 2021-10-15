using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSColors : FloatSource
    {
        public string ColorId { get; set; }
        public bool Permanent { get; set; }

        public FSColors()
        {
        }

        internal FSColors(BulkSerializer reader) : base(reader)
        {
            ColorId = reader.ReadString();
            Permanent = reader.ReadBool();
        }
    }
}