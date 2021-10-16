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

        internal SASetHitboxFX(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            FxId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(FxId);
        }
    }
}