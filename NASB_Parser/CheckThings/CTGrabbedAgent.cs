using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTGrabbedAgent : CheckThing
    {
        public List<string> MatchTags { get; }

        public CTGrabbedAgent()
        {
            MatchTags = new List<string>();
        }

        internal CTGrabbedAgent(BulkSerializer reader) : base(reader)
        {
            int len = reader.ReadInt();
            if (len > 0)
            {
                MatchTags = new List<string>(len);
                for (int i = 0; i < len; i++)
                {
                    MatchTags.Add(reader.ReadString());
                }
            }
            else
            {
                MatchTags = new List<string>();
            }
        }
    }
}