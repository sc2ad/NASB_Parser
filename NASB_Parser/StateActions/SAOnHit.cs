using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOnHit : StateAction
    {
        public bool Hitbox { get; set; }
        public int Box { get; set; }
        public StateAction Action { get; set; }

        public SAOnHit()
        {
        }

        internal SAOnHit(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadBool();
            Box = reader.ReadInt();
            Action = Read(reader);
        }
    }
}