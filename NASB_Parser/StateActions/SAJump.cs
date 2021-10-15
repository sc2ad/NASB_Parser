using NASB_Parser.Jumps;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAJump : StateAction
    {
        public string JumpId { get; set; }
        public Jump Jump { get; set; }

        public SAJump()
        {
        }

        internal SAJump(BulkSerializer reader) : base(reader)
        {
            JumpId = reader.ReadString();
            Jump = Jump.Read(reader);
        }
    }
}