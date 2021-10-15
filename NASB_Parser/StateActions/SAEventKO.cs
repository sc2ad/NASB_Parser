using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAEventKO : StateAction
    {
        public KOType KO { get; set; }

        public SAEventKO()
        {
        }

        internal SAEventKO(BulkSerializer reader) : base(reader)
        {
            KO = (KOType)reader.ReadInt();
        }

        public enum KOType
        {
            Top,
            Left,
            Right,
            Bottom,
            Box,
            Enemy,
            Grabbed,
            Critical
        }
    }
}