using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class LookForInput : ISerializable
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

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(MatchMinFrames);
            writer.Write(InputValidator);
        }
    }
}