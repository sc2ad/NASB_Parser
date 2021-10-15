using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSEffects : FloatSource
    {
        public string LocalFxId { get; set; }
        public ManipAspect Masp { get; set; }

        public FSEffects()
        {
        }

        internal FSEffects(BulkSerializer reader) : base(reader)
        {
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