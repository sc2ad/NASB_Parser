using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSSpeed : FloatSource
    {
        public FSSpeedType SpeedType { get; set; }

        public FSSpeed()
        {
        }

        internal FSSpeed(BulkSerializeReader reader) : base(reader)
        {
            SpeedType = (FSSpeedType)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SpeedType);
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