using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAFindLastHorizontalInput : StateAction
    {
        public SearchType Search { get; set; }
        public int ResultInScratch { get; set; }

        public SAFindLastHorizontalInput()
        {
        }

        internal SAFindLastHorizontalInput(BulkSerializeReader reader) : base(reader)
        {
            Search = (SearchType)reader.ReadInt();
            ResultInScratch = reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Search);
            writer.Write(ResultInScratch);
        }

        public enum SearchType
        {
            None,
            NormalButtonDown,
            StrongButtonDown,
            SpecialButtonDown,
            AnyCombatButtonDown,
            None2nd
        }
    }
}