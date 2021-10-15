using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAAlterMoveDT : StateAction
    {
        public bool ClearAMDT { get; set; }
        public FloatSource After { get; set; }
        public FloatSource Falloff { get; set; }

        public SAAlterMoveDT()
        {
        }

        internal SAAlterMoveDT(BulkSerializer reader) : base(reader)
        {
            ClearAMDT = reader.ReadBool();
            After = FloatSource.Read(reader);
            Falloff = FloatSource.Read(reader);
        }
    }
}