using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSGrabs : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSGrabs()
        {
        }

        internal FSGrabs(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            HardSyncPos,
            AllowGrabEscape,
            AllowedToEscape,
            GrabbedAgentWeight,
            GrabbedByPlayerIndex,
            GrabbedByAttackTeam
        }
    }
}