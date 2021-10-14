using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSEffects : FloatSource
    {
        public string LocalFxId { get; set; }
        public ManipAspect Masp { get; set; }

        public FSEffects()
        {
        }

        internal FSEffects(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            LocalFxId = reader.ReadString();
        }

        public enum ManipAspect
        {
            TimeElapsed,

            Length,

            AddToElapsed
        }
    }
}