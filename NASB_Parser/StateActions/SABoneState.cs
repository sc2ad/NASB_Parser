using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SABoneState : StateAction
    {
        public bool State { get; set; }
        public string Bone { get; set; }

        public SABoneState()
        {
        }

        internal SABoneState(BulkSerializer reader) : base(reader)
        {
            State = reader.ReadBool();
            Bone = reader.ReadString();
        }
    }
}