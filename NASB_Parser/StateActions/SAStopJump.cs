using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStopJump : StateAction
    {
        public bool StopAll { get; set; }
        public string JumpId { get; set; }
        public List<string> JumpIds { get; private set; } = new List<string>();

        public SAStopJump()
        { }

        internal SAStopJump(BulkSerializeReader reader) : base(reader)
        {
            StopAll = reader.ReadBool();
            JumpId = reader.ReadString();
            
            if (Version > 0)
            {
                JumpIds = reader.ReadList(r => r.ReadString());
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(StopAll);
            writer.Write(JumpId);
            writer.Write(JumpIds);
        }
    }
}