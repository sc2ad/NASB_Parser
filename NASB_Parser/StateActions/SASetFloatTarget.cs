using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SASetFloatTarget : StateAction
    {
        public List<SetFloat> Sets { get; } = new List<SetFloat>();

        public SASetFloatTarget()
        {
        }

        internal SASetFloatTarget(BulkSerializeReader reader) : base(reader)
        {
            Sets = reader.ReadList(r => new SetFloat(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Sets);
        }

        public class SetFloat : ISerializable
        {
            public FloatSource Target { get; set; }
            public FloatSource Source { get; set; }
            public ManipWay Way { get; set; }

            public SetFloat()
            {
            }

            internal SetFloat(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Target = FloatSource.Read(reader);
                Source = FloatSource.Read(reader);
                Way = (ManipWay)reader.ReadInt();
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(Target);
                writer.Write(Source);
                writer.Write(Way);
            }

            public enum ManipWay
            {
                Set,
                Add,
                Mult
            }
        }
    }
}