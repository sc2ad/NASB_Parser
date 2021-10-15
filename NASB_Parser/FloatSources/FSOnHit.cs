using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSOnHit : FloatSource
    {
        public OnHitParam Param { get; set; }

        public FSOnHit()
        {
        }

        internal FSOnHit(BulkSerializer reader) : base(reader)
        {
            Param = (OnHitParam)reader.ReadInt();
        }

        public enum OnHitParam
        {
            Hitpos_x,
            Hitpos_y,
            Hitpos_z,
            Hitwasinvincible,
            Hitwasblock,
            Hitwellblocked = 6,
            Hitperfectblocked,
            Hurtdamage = 5,
            Hurtknockback = 12,
            Hitdamage = 9,
            Hurtwellblocked = 11,
            Hurtperfectblocked = 8,
            Hurtattacktype = 10
        }
    }
}