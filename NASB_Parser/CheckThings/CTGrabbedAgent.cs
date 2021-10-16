using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTGrabbedAgent : CheckThing
    {
        public List<string> MatchTags { get; } = new List<string>();

        public CTGrabbedAgent()
        {
        }

        internal CTGrabbedAgent(BulkSerializeReader reader) : base(reader)
        {
            MatchTags = reader.ReadList(r => r.ReadString());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MatchTags);
        }
    }
}