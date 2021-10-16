using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOrderedSensitive : StateAction
    {
        public List<StateAction> Actions { get; private set; } = new List<StateAction>();

        public SAOrderedSensitive()
        {
        }

        internal SAOrderedSensitive(BulkSerializeReader reader) : base(reader)
        {
            Actions = reader.ReadList(r => Read(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Actions);
        }
    }
}