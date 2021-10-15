using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSCollision : FloatSource
    {
        public CollisionAttributes CollisionAttribute { get; set; }

        public FSCollision()
        {
        }

        internal FSCollision(BulkSerializer reader) : base(reader)
        {
            CollisionAttribute = (CollisionAttributes)reader.ReadInt();
        }

        public enum CollisionAttributes
        {
            TouchBottom,
            TouchTop,
            TouchLeft,
            TouchRight,
            ParentOrderAdded
        }
    }
}