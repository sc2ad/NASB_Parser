using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTMultiple : CheckThing
    {
        public CheckMatch Match { get; set; } = CheckMatch.All;
        public List<CheckThing> Checklist { get; }

        public CTMultiple()
        {
            Checklist = new List<CheckThing>();
        }

        internal CTMultiple(BulkSerializer reader) : base(reader)
        {
            Match = (CheckMatch)reader.ReadInt();
            int len = reader.ReadInt();
            if (len >= 0)
            {
                Checklist = new List<CheckThing>(len);
                for (int i = 0; i < len; i++)
                {
                    Checklist.Add(Read(reader));
                }
            }
            else
            {
                Checklist = new List<CheckThing>();
            }
        }

        public enum CheckMatch
        {
            Any,
            All,
            One,
            None
        }
    }
}