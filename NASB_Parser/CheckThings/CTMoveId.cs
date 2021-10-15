using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTMoveId : CheckThing
    {
        public string MovesetId { get; set; }
        public bool Previous { get; set; }
        public List<string> Extras { get; } = new List<string>();

        public CTMoveId()
        {
        }

        internal CTMoveId(BulkSerializer reader)
        {
            MovesetId = reader.ReadString();
            Previous = reader.ReadBool();
            Extras = reader.ReadList(r => r.ReadString());
        }
    }
}