using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSPhysics : FloatSource
    {
        public PhysicsAttributes PhysicsAttribute { get; set; }

        public FSPhysics()
        {
        }

        internal FSPhysics(BulkSerializer reader) : base(reader)
        {
            PhysicsAttribute = (PhysicsAttributes)reader.ReadInt();
        }

        public enum PhysicsAttributes
        {
            Gravity
        }
    }
}