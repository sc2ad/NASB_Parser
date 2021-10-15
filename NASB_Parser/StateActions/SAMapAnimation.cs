using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimation : StateAction
    {
        public List<MapPoint> Map { get; } = new List<MapPoint>();

        public SAMapAnimation()
        {
        }

        internal SAMapAnimation(BulkSerializer reader) : base(reader)
        {
            Map = reader.ReadList(r => new MapPoint(r));
        }

        public class MapPoint
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

            internal MapPoint(BulkSerializer reader)
            {
                _ = reader.ReadInt();
                RootAnim = reader.ReadBool();
                AnimId = reader.ReadString();
                AtFrames = FloatSource.Read(reader);
                Frames = FloatSource.Read(reader);
                StartAnimFrame = FloatSource.Read(reader);
                EndAnimFrame = FloatSource.Read(reader);
            }
        }
    }
}