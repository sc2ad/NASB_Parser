using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetHitboxSFX : StateAction
    {
        public int Hitbox { get; set; }
        public string SfxId { get; set; }

        public SASetHitboxSFX()
        {
        }

        internal SASetHitboxSFX(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            SfxId = reader.ReadString();
        }
    }
}