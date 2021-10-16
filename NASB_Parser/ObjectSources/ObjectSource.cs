using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
    public class ObjectSource : ISerializable
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public ObjectSource()
        {
        }

        internal ObjectSource(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static ObjectSource Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.FloatId => new OSFloat(reader),
                TypeId.Vector2Id => new OSVector2(reader),
                TypeId.BaseIdentifier => new ObjectSource(reader),
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(ObjectSource)} type from: {reader.PeekInt()}!"),
            };
        }

        public enum TypeId
        {
            BaseIdentifier,
            FloatId,
            Vector2Id
        }
    }
}