using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetupHurtboxes : StateAction
    {
        public HurtSetSetup HurtSetSetup { get; set; }

        public SASetupHurtboxes()
        {
        }

        internal SASetupHurtboxes(BulkSerializer reader) : base(reader)
        {
            HurtSetSetup = new HurtSetSetup(reader);
        }
    }
}