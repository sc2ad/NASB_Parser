using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTMove : CheckThing
    {
        public string MovesetId { get; set; }
        public bool Previous { get; set; }
        public List<string> Extras { get; private set; } = new List<string>();

        public CTMove()
        {
        }

        internal CTMove(BulkSerializeReader reader) : base(reader)
        {
            MovesetId = reader.ReadString();
            Previous = reader.ReadBool();
            Extras = reader.ReadList(r => r.ReadString());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MovesetId);
            writer.Write(Previous);
            writer.Write(Extras);
        }
    }
}