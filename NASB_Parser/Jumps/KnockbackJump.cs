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
        public bool DoLaunch { get; set; }
        public FloatSource BounceMinVel { get; set; }

        public KnockbackJump()
        {
        }

        internal KnockbackJump(BulkSerializeReader reader) : base(reader)
        {
            XDir = FloatSource.Read(reader);
            YDir = FloatSource.Read(reader);
            LaunchDist = FloatSource.Read(reader);
            Frames = FloatSource.Read(reader);

            if (Version <= 2)
            {
                // Read in the old DiType, DiAngleIn, and DiAngleOut, but ignore them
                FloatSource.Read(reader);
                FloatSource.Read(reader);
                FloatSource.Read(reader);
            }
            
            if (Version == 0) return;

            DoLaunch = reader.ReadBool();

            if (Version == 1) return;

            BounceMinVel = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(XDir);
            writer.Write(YDir);
            writer.Write(LaunchDist);
            writer.Write(Frames);
            writer.Write(DoLaunch);
            writer.Write(BounceMinVel);
        }
    }
}