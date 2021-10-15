using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SARefreshAttack : StateAction
    {
        public SARefreshAttack()
        {
        }

        internal SARefreshAttack(BulkSerializer reader) : base(reader)
        {
        }
    }
}