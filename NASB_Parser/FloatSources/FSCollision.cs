using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSCollision : FloatSource
    {
        public CollisionAttributes Attribute { get; set; }

        public FSCollision()
        {
        }

        internal FSCollision(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (CollisionAttributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
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