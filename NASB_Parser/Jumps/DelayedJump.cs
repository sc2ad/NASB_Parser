using NASB_Parser.FloatSources;

namespace NASB_Parser.Jumps
{
    public class DelayedJump : Jump
    {
        public FloatSource Height { get; set; }
        public FloatSource AutoHoldFrames { get; set; }
        public FloatSource YVelMaxOnRelease { get; set; }

        public DelayedJump()
        {
        }

        internal DelayedJump(BulkSerializeReader reader) : base(reader)
        {
            Height = FloatSource.Read(reader);
            AutoHoldFrames = FloatSource.Read(reader);
            YVelMaxOnRelease = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Height);
            writer.Write(AutoHoldFrames);
            writer.Write(YVelMaxOnRelease);
        }
    }
}
