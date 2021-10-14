using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTDoubleTapId : CheckThing
    {
        public SimpleControlDir TapDir { get; set; }
        public int Window { get; set; }

        public CTDoubleTapId()
        {
        }

        internal CTDoubleTapId(BulkSerializer reader) : base(reader)
        {
            TapDir = (SimpleControlDir)reader.ReadInt();
            Window = reader.ReadInt();
        }

        public enum SimpleControlDir
        {
            Neutral,
            Right,
            Left,
            Up,
            Down,
            Forward,
            Backward
        }
    }
}