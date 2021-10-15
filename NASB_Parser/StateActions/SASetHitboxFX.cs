using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetHitboxFX : StateAction
    {
        public int Hitbox { get; set; }
        public string FxId { get; set; }

        public SASetHitboxFX()
        {
        }

        internal SASetHitboxFX(BulkSerializer reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            FxId = reader.ReadString();
        }
    }
}