using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SATimedAction : StateAction
    {
        public FloatSource Source { get; set; }
        public bool Repeat { get; set; }
        public StateAction Action { get; set; }

        public SATimedAction()
        {
        }

        internal SATimedAction(BulkSerializeReader reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
            Repeat = reader.ReadBool();
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Source);
            writer.Write(Repeat);
            writer.Write(Action);
        }
    }
}