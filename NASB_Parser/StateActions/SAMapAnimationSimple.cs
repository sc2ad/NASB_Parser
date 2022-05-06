using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimationSimple : StateAction {

        public List<MapPoint> Map { get; private set; } = new List<MapPoint>();

        public bool RootAnim { get; set; }
        public string AnimId { get; set; }
        public FloatSource AtFrames { get; set; }
        public FloatSource Frames { get; set; }
        public FloatSource StartAnimFrame { get; set; }
        public FloatSource EndAnimFrame { get; set; }

        public SAMapAnimationSimple() {
        }

        internal SAMapAnimationSimple(BulkSerializeReader reader) : base(reader) {
            AnimId = reader.ReadString();
            RootAnim = reader.ReadBool();
            int index = reader.ReadInt();
            Map = reader.ReadList(r => new MapPoint(r));
        }

        public override void Write(BulkSerializeWriter writer) {
            base.Write(writer);
            writer.Write(AnimId);
            writer.Write(RootAnim);
            writer.Write(Map);
        }

        public class MapPoint : ISerializable {

            public FloatSource offsetFrame { get; set; }
            public FloatSource animFrame { get; set; }

            public MapPoint() {
            }

            internal MapPoint(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                offsetFrame = FloatSource.Read(reader);
                animFrame = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer) {
                writer.Write(0);
                writer.Write(offsetFrame);
                writer.Write(animFrame);
            }
        }
    }
}