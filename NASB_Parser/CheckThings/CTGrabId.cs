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

        internal CTGrabId(BulkSerializeReader reader) : base(reader)
        {
            CheckType = (CheckTypes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CheckType);
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