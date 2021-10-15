using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSScratch : FloatSource
    {
        public int Scratch { get; set; }

        public FSScratch()
        {
        }

        internal FSScratch(BulkSerializer reader) : base(reader)
        {
            Scratch = reader.ReadInt();
        }
    }
}