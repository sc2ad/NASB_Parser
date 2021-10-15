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

        internal SASetFloatTarget(BulkSerializer reader) : base(reader)
        {
            Sets = reader.ReadList(r => new SetFloat(r));
        }

        public class SetFloat
        {
            public FloatSource Target { get; set; }
            public FloatSource Source { get; set; }
            public ManipWay Way { get; set; }

            public SetFloat()
            {
            }

            internal SetFloat(BulkSerializer reader)
            {
                _ = reader.ReadInt();
                Target = FloatSource.Read(reader);
                Source = FloatSource.Read(reader);
                Way = (ManipWay)reader.ReadInt();
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