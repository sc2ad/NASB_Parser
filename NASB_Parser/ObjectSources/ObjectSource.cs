using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.ObjectSources
{
    public class ObjectSource
    {
        public TypeId Id { get; }
        public int Version { get; }

        public ObjectSource()
        {
        }

        internal ObjectSource(BulkSerializer reader)
        {
            Id = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public static ObjectSource Read(BulkSerializer reader)
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