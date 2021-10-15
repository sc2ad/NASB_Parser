using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTCheckTech : CheckThing
    {
        public string TechTimerId { get; set; }

        public CTCheckTech()
        {
        }

        internal CTCheckTech(BulkSerializeReader reader) : base(reader)
        {
            TechTimerId = reader.ReadString();
        }
    }
}