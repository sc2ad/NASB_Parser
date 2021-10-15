using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOnCancel : StateAction
    {
        public string Id { get; set; }
        public StateAction Action { get; set; }

        public SAOnCancel()
        {
        }

        internal SAOnCancel(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
            Action = Read(reader);
        }
    }
}