using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class AirDashJump : Jump
    {
        public Ease EaseSpeed { get; set; }
        public FloatSource XDir { get; set; }
        public FloatSource YDir { get; set; }
        public FloatSource SpeedStart { get; set; }
        public FloatSource SpeedEnd { get; set; }
        public FloatSource SpeedUpMult { get; set; }
        public FloatSource SpeedDownMult { get; set; }
        public FloatSource Frames { get; set; }
        public FloatSource RedirectFrames { get; set; }

        public AirDashJump()
        {
        }

        internal AirDashJump(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            bool hasSpeedDown = reader.ReadBool();
            EaseSpeed = (Ease)reader.ReadInt();
            XDir = FloatSource.Read(reader);
            YDir = FloatSource.Read(reader);
            SpeedStart = FloatSource.Read(reader);
            SpeedEnd = FloatSource.Read(reader);
            SpeedUpMult = FloatSource.Read(reader);
            if (hasSpeedDown)
            {
                SpeedDownMult = FloatSource.Read(reader);
            }
            Frames = FloatSource.Read(reader);
            RedirectFrames = FloatSource.Read(reader);
        }
    }
}