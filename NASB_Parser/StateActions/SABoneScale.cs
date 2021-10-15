using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SABoneScale : StateAction
    {
        public string Bone { get; set; }
        public FloatSource Source { get; set; }

        public SABoneScale()
        {
        }

        internal SABoneScale(BulkSerializer reader) : base(reader)
        {
            Bone = reader.ReadString();
            Source = FloatSource.Read(reader);
        }
    }
}