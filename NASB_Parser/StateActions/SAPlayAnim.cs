using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPlayAnim : StateAction
    {
        public bool FromStart { get; set; }
        public string Anim { get; set; }
        public AnimConfig Cfg { get; set; }

        public SAPlayAnim()
        {
        }

        internal SAPlayAnim(BulkSerializer reader) : base(reader)
        {
            FromStart = reader.ReadBool();
            Anim = reader.ReadString();
            Cfg = new AnimConfig(reader);
        }
    }
}