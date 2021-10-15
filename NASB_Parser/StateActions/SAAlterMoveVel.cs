﻿using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAAlterMoveVel : StateAction
    {
        public bool ClearAMV { get; set; }
        public FloatSource AlterX { get; set; }
        public FloatSource AlterY { get; set; }
        public FloatSource FalloffX { get; set; }
        public FloatSource FalloffY { get; set; }

        public SAAlterMoveVel()
        {
        }

        internal SAAlterMoveVel(BulkSerializer reader) : base(reader)
        {
            ClearAMV = reader.ReadBool();
            AlterX = FloatSource.Read(reader);
            AlterY = FloatSource.Read(reader);
            FalloffX = FloatSource.Read(reader);
            FalloffY = FloatSource.Read(reader);
        }
    }
}