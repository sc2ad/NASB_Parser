using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimationSimple : StateAction
    {
        public string AnimId { get; set; }
        public bool RootAnim { get; set; }
        public List<MapPoint> Map { get; private set; } = new List<MapPoint>();

        public SAMapAnimationSimple()
        {
        }

        internal SAMapAnimationSimple(BulkSerializeReader reader) : base(reader)
        {
            AnimId = reader.ReadString();
            RootAnim = reader.ReadBool();

            Map = reader.ReadList(r => new MapPoint(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AnimId);
            writer.Write(RootAnim);
            writer.Write(Map);
        }

        public class MapPoint : ISerializable
        {
            public FloatSource OffsetFrame { get; set; }
            public FloatSource AnimFrame { get; set; }

            public MapPoint()
            {
            }

            internal MapPoint(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                OffsetFrame = FloatSource.Read(reader);
                AnimFrame = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.AddInt(0);
                writer.Write(OffsetFrame);
                writer.Write(AnimFrame);
            }
        }
    }
}
