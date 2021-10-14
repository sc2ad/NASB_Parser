using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SATimedAction : StateAction
    {
        public FloatSource Source { get; set; }
        public bool Repeat { get; set; }
        public StateAction Action { get; set; }

        public SATimedAction()
        {
        }

        internal SATimedAction(BulkSerializer reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
            Repeat = reader.ReadInt() > 0;
            Action = Read(reader);
        }
    }
}