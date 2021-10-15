using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAEndAttack : StateAction
    {
        public SAEndAttack()
        {
        }

        internal SAEndAttack(BulkSerializer reader) : base(reader)
        {
        }
    }
}