using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACameraShake : StateAction
    {
        public float Shake { get; set; }
        public float Intensity { get; set; } = 1;

        public SACameraShake()
        {
        }

        internal SACameraShake(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            bool hasIntensity = reader.ReadInt() != 0;
            Shake = reader.ReadFloat();
            if (hasIntensity)
            {
                Intensity = reader.ReadFloat();
            }
        }
    }
}