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

        internal SASetStagePart(BulkSerializeReader reader) : base(reader)
        {
            SetTo = reader.ReadBool();
            PartId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SetTo);
            writer.Write(PartId);
        }
    }
}