using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SADeactivateInputAction : StateAction
    {
        public string Id { get; set; }

        public SADeactivateInputAction()
        {
        }

        internal SADeactivateInputAction(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }
    }
}