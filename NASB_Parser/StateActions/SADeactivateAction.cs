using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SADeactivateAction : StateAction
    {
        public int Index { get; set; }
        public string Id { get; set; }

        public SADeactivateAction()
        {
        }

        internal SADeactivateAction(BulkSerializer reader)
        {
            Index = reader.ReadInt();
            Id = reader.ReadString();
        }
    }
}