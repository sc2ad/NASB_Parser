using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACancelToState : StateAction
    {
        public string ToState { get; set; }
        public bool Soft { get; set; }

        public SACancelToState()
        {
        }

        internal SACancelToState(BulkSerializeReader reader) : base(reader)
        {
            ToState = reader.ReadString();
            Soft = reader.ReadBool();
        }
    }
}