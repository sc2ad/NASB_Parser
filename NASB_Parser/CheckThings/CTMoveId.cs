using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTMoveId : CheckThing
    {
        public string MovesetId { get; set; }
        public bool Previous { get; set; }
        public List<string> Extras { get; }

        public CTMoveId()
        {
            Extras = new List<string>();
        }

        internal CTMoveId(BulkSerializer reader)
        {
            MovesetId = reader.ReadString();
            Previous = reader.ReadInt() > 0;
            int len = reader.ReadInt();
            if (len > 0)
            {
                Extras = new List<string>(len);
                for (int i = 0; i < len; i++)
                {
                    Extras.Add(reader.ReadString());
                }
            }
            else
            {
                Extras = new List<string>();
            }
        }
    }
}