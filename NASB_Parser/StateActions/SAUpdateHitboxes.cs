using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAUpdateHitboxes : StateAction
    {
        public SAUpdateHitboxes()
        {
        }

        internal SAUpdateHitboxes(BulkSerializeReader reader) : base(reader)
        {
        }
    }
}