using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPlayRootAnim : StateAction
    {
        public string Anim { get; set; }
        public float Rate { get; set; }
        public bool SetRateOnly { get; set; }
        public float Frame { get; set; }
        public bool SetFrame { get; set; }

        public SAPlayRootAnim()
        {
        }

        internal SAPlayRootAnim(BulkSerializer reader) : base(reader)
        {
            Anim = reader.ReadString();
            Rate = reader.ReadFloat();
            SetRateOnly = reader.ReadInt() > 0;
            Frame = reader.ReadFloat();
            SetFrame = reader.ReadInt() > 0;
        }
    }
}