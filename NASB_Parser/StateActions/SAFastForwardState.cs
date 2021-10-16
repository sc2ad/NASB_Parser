using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFastForwardState : StateAction
    {
        public FloatSource Frames { get; set; }

        public SAFastForwardState()
        {
        }

        internal SAFastForwardState(BulkSerializeReader reader) : base(reader)
        {
            Frames = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Frames);
        }
    }
}