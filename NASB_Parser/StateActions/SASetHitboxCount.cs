using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetHitboxCount : StateAction
    {
        public int HitboxCount { get; set; }

        public SASetHitboxCount()
        {
        }

        internal SASetHitboxCount(BulkSerializeReader reader) : base(reader)
        {
            HitboxCount = reader.ReadInt();
        }
    }
}