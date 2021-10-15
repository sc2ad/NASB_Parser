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

        internal FSAttack(BulkSerializer reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
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