using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;
    }

    public static class ReaderExtensions
    {
        public static Vector3 ReadVector3(this BulkSerializeReader reader)
        {
            return new Vector3 { x = reader.ReadFloat(), y = reader.ReadFloat(), z = reader.ReadFloat() };
        }
    }
}