using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSItem : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSItem()
        {
        }

        internal FSItem(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }

        public enum Attributes
        {
            ActivatedByHit,
            ActivatedByGrab,
            ActivatedByThrow,
            Weapon,
            Avoid,
            Beneficial,
            InterestWeight
        }
    }
}