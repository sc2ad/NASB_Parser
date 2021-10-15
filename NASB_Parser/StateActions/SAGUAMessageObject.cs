using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.ObjectSources;

namespace NASB_Parser.StateActions
{
    public class SAGUAMessageObject
    {
        public string PlainMessage { get; set; }
        public List<MessageDynamic> Dynamics { get; } = new List<MessageDynamic>();

        public SAGUAMessageObject()
        {
        }

        internal SAGUAMessageObject(BulkSerializeReader reader)
        {
            PlainMessage = reader.ReadString();
            Dynamics = reader.ReadList(r => new MessageDynamic(r));
        }

        public class MessageDynamic
        {
            public string Id { get; set; }
            public ObjectSource ObjectSource { get; set; }

            public MessageDynamic()
            {
            }

            internal MessageDynamic(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Id = reader.ReadString();
                ObjectSource = ObjectSource.Read(reader);
            }
        }
    }
}