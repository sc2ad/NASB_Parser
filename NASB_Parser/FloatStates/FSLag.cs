using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSLag : FloatSource
    {
        public LagTypes LagType { get; set; }
        public ManipLags ManipLag { get; set; }

        public FSLag()
        {
        }

        internal FSLag(BulkSerializer reader) : base(reader)
        {
            LagType = (LagTypes)reader.ReadInt();
            ManipLag = (ManipLags)reader.ReadInt();
        }

        public enum LagTypes
        {
            StateLag,
            MoveLag,
            Both
        }

        public enum ManipLags
        {
            Set,
            Add,
            Max
        }
    }
}