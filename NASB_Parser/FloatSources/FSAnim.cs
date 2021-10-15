using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSAnim : FloatSource
    {
        public string Anim { get; set; }
        public AnimAttr Attribute { get; set; }

        public FSAnim()
        {
        }

        internal FSAnim(BulkSerializer reader) : base(reader)
        {
            Anim = reader.ReadString();
            Attribute = (AnimAttr)reader.ReadInt();
        }

        public enum AnimAttr
        {
            Rate,
            Weight,
            AtTime,
            AtFrame,
            RealWeight,
            Exists,
            FrameLength
        }
    }
}