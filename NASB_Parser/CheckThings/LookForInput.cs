using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class LookForInput
    {
        public int MatchMinFrames { get; set; }
        public InputValidator InputValidator { get; set; }

        public LookForInput()
        {
        }

        internal LookForInput(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            MatchMinFrames = reader.ReadInt();
            InputValidator = new InputValidator(reader);
        }
    }
}