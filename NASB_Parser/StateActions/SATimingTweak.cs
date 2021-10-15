using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SATimingTweak : StateAction
    {
        public string AnimId { get; set; }
        public string RootAnimId { get; set; }
        public AnimConfig AnimCfg { get; set; }
        public FloatSource AnimFrames { get; set; }
        public FloatSource StateFrames { get; set; }
        public FloatSource FramesToA { get; set; }
        public FloatSource FramesToB { get; set; }
        public StateAction ActionA { get; set; }
        public StateAction ActionB { get; set; }
        public StateAction ActionEnd { get; set; }

        public SATimingTweak()
        {
        }

        internal SATimingTweak(BulkSerializeReader reader) : base(reader)
        {
            AnimId = reader.ReadString();
            RootAnimId = reader.ReadString();
            AnimCfg = new AnimConfig(reader);
            AnimFrames = FloatSource.Read(reader);
            StateFrames = FloatSource.Read(reader);
            FramesToA = FloatSource.Read(reader);
            FramesToB = FloatSource.Read(reader);
            ActionA = Read(reader);
            ActionB = Read(reader);
            ActionEnd = Read(reader);
        }
    }
}