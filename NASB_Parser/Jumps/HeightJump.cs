using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
    public class HeightJump : Jump
    {
        public FloatSource Height { get; set; }

        public HeightJump()
        {
        }

        internal HeightJump(BulkSerializer reader) : base(reader)
        {
            Height = FloatSource.Read(reader);
        }
    }
}