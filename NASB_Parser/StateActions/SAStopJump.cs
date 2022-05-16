using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStopJump : StateAction
    {
        public bool StopAll { get; set; }
        public string JumpId { get; set; }
        public string[] JumpIds { get; set; }

        public SAStopJump()
        { }

        internal SAStopJump(BulkSerializeReader reader) : base(reader)
        {
            StopAll = reader.ReadBool();
            JumpId = reader.ReadString();
            
            if (Version > 0)
            {
                int numJumpIds = reader.ReadInt();
                for (int i = 0; i < numJumpIds; i++)
                {
                    JumpIds[i] = reader.ReadString();
                }
            } else
            {
                JumpIds = new string[0];
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(StopAll);
            writer.Write(JumpId);
            writer.Write(JumpId.Length);
            for (int i = 0; i < JumpIds.Length; i++)
            {
                writer.Write(JumpIds[i]);
            }
        }
    }
}