using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
    public class OSVector2 : ObjectSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public OSVector2()
        {
        }

        internal OSVector2(BulkSerializer reader) : base(reader)
        {
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
        }
    }
}