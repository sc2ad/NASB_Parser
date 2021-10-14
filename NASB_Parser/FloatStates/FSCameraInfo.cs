using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSCameraInfo : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCameraInfo()
        {
        }

        internal FSCameraInfo(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
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