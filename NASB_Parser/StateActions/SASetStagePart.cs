using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetStagePart : StateAction
    {
        public bool SetTo { get; set; }
        public string PartId { get; set; }

        public SASetStagePart()
        {
        }

        internal SASetStagePart(BulkSerializer reader) : base(reader)
        {
            SetTo = reader.ReadBool();
            PartId = reader.ReadString();
        }
    }
}