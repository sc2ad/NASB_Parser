using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSSpeed : FloatSource
    {
        public FSSpeedType SpeedType { get; set; }

        public FSSpeed()
        {
        }

        internal FSSpeed(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            SpeedType = (FSSpeedType)reader.ReadInt();
        }

        public enum FSSpeedType
        {
            GameSpeed,
            StateDT,
            MovementDT,
            StateDTF,
            MovementDTF,
            GameSeconds
        }
    }
}