using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class HurtSetSetup
    {
        public List<HurtBone> HurtBones { get; } = new List<HurtBone>();

        public HurtSetSetup()
        {
        }

        internal HurtSetSetup(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            HurtBones = reader.ReadList(r => new HurtBone(r));
        }
    }
}