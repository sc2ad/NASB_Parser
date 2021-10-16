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

        internal SAPlayRootAnim(BulkSerializeReader reader) : base(reader)
        {
            Anim = reader.ReadString();
            Rate = reader.ReadFloat();
            SetRateOnly = reader.ReadBool();
            Frame = reader.ReadFloat();
            SetFrame = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Anim);
            writer.Write(Rate);
            writer.Write(SetRateOnly);
            writer.Write(Frame);
            writer.Write(SetFrame);
        }
    }
}