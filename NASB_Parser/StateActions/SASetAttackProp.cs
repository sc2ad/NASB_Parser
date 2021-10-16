using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetAttackProp : StateAction
    {
        public int Hitbox { get; set; }
        public string Prop { get; set; }

        public SASetAttackProp()
        {
        }

        internal SASetAttackProp(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            Prop = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(Prop);
        }
    }
}