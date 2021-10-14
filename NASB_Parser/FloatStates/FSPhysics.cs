using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSPhysics : FloatSource
    {
        public PhysicsAttributes PhysicsAttribute { get; set; }

        public FSPhysics()
        {
        }

        internal FSPhysics(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            PhysicsAttribute = (PhysicsAttributes)reader.ReadInt();
        }

        public enum PhysicsAttributes
        {
            Gravity
        }
    }
}