using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACameraPunch : StateAction
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }
        public FloatSource Z { get; set; }
        public FloatSource T { get; set; }

        public SACameraPunch()
        {
        }

        internal SACameraPunch(BulkSerializer reader) : base(reader)
        {
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
            Z = FloatSource.Read(reader);
            T = FloatSource.Read(reader);
        }
    }
}