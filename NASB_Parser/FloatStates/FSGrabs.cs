using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSGrabs : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSGrabs()
        {
        }

        internal FSGrabs(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
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