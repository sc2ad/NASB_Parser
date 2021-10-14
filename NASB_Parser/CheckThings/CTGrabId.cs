using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTGrabId : CheckThing
    {
        public CheckTypes CheckType { get; set; }

        public CTGrabId()
        {
        }

        internal CTGrabId(BulkSerializer reader) : base(reader)
        {
            CheckType = (CheckTypes)reader.ReadInt();
        }

        public enum CheckTypes
        {
            InGrab,
            IsGrabber,
            IsGrabbed,
            AllowedToEscape
        }
    }
}