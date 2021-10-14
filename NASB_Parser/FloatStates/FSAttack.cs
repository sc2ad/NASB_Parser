using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSAttack : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSAttack()
        {
        }

        internal FSAttack(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
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