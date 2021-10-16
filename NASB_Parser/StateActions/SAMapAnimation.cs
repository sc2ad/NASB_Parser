using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimation : StateAction
    {
        public List<MapPoint> Map { get; private set; } = new List<MapPoint>();

        public SAMapAnimation()
        {
        }

        internal SAMapAnimation(BulkSerializeReader reader) : base(reader)
        {
            Map = reader.ReadList(r => new MapPoint(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Map);
        }

        public class MapPoint : ISerializable
        {
            public bool RootAnim { get; set; }
            public string AnimId { get; set; }
            public FloatSource AtFrames { get; set; }
            public FloatSource Frames { get; set; }
            public FloatSource StartAnimFrame { get; set; }
            public FloatSource EndAnimFrame { get; set; }

            public MapPoint()
            {
            }

            internal MapPoint(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                RootAnim = reader.ReadBool();
                AnimId = reader.ReadString();
                AtFrames = FloatSource.Read(reader);
                Frames = FloatSource.Read(reader);
                StartAnimFrame = FloatSource.Read(reader);
                EndAnimFrame = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(RootAnim);
                writer.Write(AnimId);
                writer.Write(AtFrames);
                writer.Write(Frames);
                writer.Write(StartAnimFrame);
                writer.Write(EndAnimFrame);
            }
        }
    }
}