using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASnapAnimWeights : StateAction
    {
        public bool ForceSample { get; set; }

        public SASnapAnimWeights()
        {
        }

        internal SASnapAnimWeights(BulkSerializer reader) : base(reader)
        {
            ForceSample = reader.ReadBool();
        }
    }
}