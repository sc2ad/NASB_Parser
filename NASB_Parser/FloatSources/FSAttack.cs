using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSAttack : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSAttack()
        {
        }

        internal FSAttack(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }

        public enum Attributes
        {
            UnIgnoreFrames,
            Dmgmult,
            Kbmult,
            NumberOfHitboxes
        }
    }
}