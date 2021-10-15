using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPlaySFX : StateAction
    {
        public string SfxId { get; set; }

        public SAPlaySFX()
        {
        }

        internal SAPlaySFX(BulkSerializeReader reader) : base(reader)
        {
            SfxId = reader.ReadString();
        }
    }
}