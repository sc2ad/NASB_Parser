using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public static class Extensions
    {
        public static Vector3 ReadVector3(this BulkSerializeReader reader)
        {
            return new Vector3 { x = reader.ReadFloat(), y = reader.ReadFloat(), z = reader.ReadFloat() };
        }

        public static void Write(this BulkSerializeWriter writer, Vector3 val)
        {
            writer.AddFloat(val.x);
            writer.AddFloat(val.y);
            writer.AddFloat(val.z);
        }

        public static void Write<T>(this BulkSerializeWriter writer, T t) where T : Enum
        {
            writer.AddInt((int)(object)t);
        }
    }
}