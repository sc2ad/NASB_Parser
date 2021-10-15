using NASB_Parser.CheckThings;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACheckThing : StateAction
    {
        public CheckThing CheckThing { get; set; }
        public StateAction Action { get; set; }
        public bool Else { get; set; }
        public StateAction ElseAction { get; set; }

        public SACheckThing()
        {
        }

        internal SACheckThing(BulkSerializeReader reader) : base(reader)
        {
            CheckThing = CheckThing.Read(reader);
            Action = Read(reader);
            Else = reader.ReadBool();
            ElseAction = Read(reader);
        }
    }
}