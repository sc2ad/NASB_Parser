using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASampleAnim : StateAction
    {
        public SASampleAnim()
        {
        }

        internal SASampleAnim(BulkSerializer reader) : base(reader)
        {
        }
    }
}