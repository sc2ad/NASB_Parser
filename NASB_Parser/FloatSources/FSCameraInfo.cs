using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSCameraInfo : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCameraInfo()
        {
        }

        internal FSCameraInfo(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }

        public enum Attributes
        {
            ActiveInclude,
            DontIncludeVertical = 14,
            CenterRadius = 1,
            TrackLastGrounded,
            AddXMovement,
            AddYUpMovement,
            AddYDownMovement,
            ClampAddYDownByFloor,
            AddUp,
            AddDown,
            AddRight,
            AddLeft,
            IncludeRespawnPoint,
            IncludeLaunchDestination,
            MoveResultsCamToFixedPos
        }
    }
}