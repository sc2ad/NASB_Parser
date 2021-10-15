using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class KnockbackJump : Jump
    {
        public FloatSource XDir { get; set; }
        public FloatSource YDir { get; set; }
        public FloatSource LaunchDist { get; set; }
        public FloatSource Frames { get; set; }
        public FloatSource DiType { get; set; }
        public FloatSource DiAngleIn { get; set; }
        public FloatSource DiAngleOut { get; set; }

        public KnockbackJump()
        {
        }

        internal KnockbackJump(BulkSerializeReader reader) : base(reader)
        {
            XDir = FloatSource.Read(reader);
            YDir = FloatSource.Read(reader);
            LaunchDist = FloatSource.Read(reader);
            Frames = FloatSource.Read(reader);
            DiType = FloatSource.Read(reader);
            DiAngleIn = FloatSource.Read(reader);
            DiAngleOut = FloatSource.Read(reader);
        }
    }
}