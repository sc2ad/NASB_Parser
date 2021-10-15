using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
    public class OSFloat : ObjectSource
    {
        public FloatSource Source { get; set; }

        public OSFloat()
        {
        }

        internal OSFloat(BulkSerializer reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
        }
    }
}