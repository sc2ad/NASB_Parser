using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.FloatSources;

namespace NASB_Parser.StateActions {
    public class SAPersistLocalFX : StateAction {

        public string id = string.Empty;

        // Token: 0x040015B7 RID: 5559
        public FloatSource persist { get; set; }

        // Token: 0x040015B8 RID: 5560
        public bool maxout;

        // Token: 0x040015B9 RID: 5561
        private int liveid = -1;

        public SAPersistLocalFX() {
        }

        internal SAPersistLocalFX(BulkSerializeReader reader) : base(reader) {
            id = reader.ReadString();
            persist = FloatSource.Read(reader);
            maxout = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)  {
            base.Write(writer);
            writer.Write(id);
            writer.Write(persist);
            writer.Write(maxout);
        }
    }
}
