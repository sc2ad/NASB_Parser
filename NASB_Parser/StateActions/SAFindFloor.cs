using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFindFloor : StateAction
    {
        public float SeekRange { get; set; }

        public SAFindFloor()
        {
        }

        internal SAFindFloor(BulkSerializeReader reader) : base(reader)
        {
            SeekRange = reader.ReadFloat();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SeekRange);
        }
    }
}