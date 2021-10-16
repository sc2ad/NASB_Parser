using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAManipDecorChain : StateAction
    {
        public int ManipIndex { get; set; }
        public ManipType Manip { get; set; }
        public FloatSource Source { get; set; }

        public SAManipDecorChain()
        {
        }

        internal SAManipDecorChain(BulkSerializeReader reader) : base(reader)
        {
            ManipIndex = reader.ReadInt();
            Manip = (ManipType)reader.ReadInt();
            Source = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ManipIndex);
            writer.Write(Manip);
            writer.Write(Source);
        }

        public enum ManipType
        {
            maxDistEnds
        }
    }
}