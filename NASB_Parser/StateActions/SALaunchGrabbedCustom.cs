using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SALaunchGrabbedCustom : StateAction
    {
        public string AtkProp { get; set; }
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public SALaunchGrabbedCustom()
        {
        }

        internal SALaunchGrabbedCustom(BulkSerializer reader) : base(reader)
        {
            AtkProp = reader.ReadString();
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
        }
    }
}