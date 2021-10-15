using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetStagePartsDefault : StateAction
    {
        public SASetStagePartsDefault()
        {
        }

        internal SASetStagePartsDefault(BulkSerializer reader) : base(reader)
        {
        }
    }
}