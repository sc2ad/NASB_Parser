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

        internal CTGrabbedAgent(BulkSerializer reader) : base(reader)
        {
            MatchTags = reader.ReadList(r => r.ReadString());
        }
    }
}