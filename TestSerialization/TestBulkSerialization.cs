using NASB_Parser;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace TestSerialization
{
    public class TestBulkSerialization
    {
        [Fact]
        public void TestDeserialize()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(5495, ser.IntCount);
            Assert.Equal(67, ser.FloatCount);
            Assert.Equal(1461, ser.FloatIdxCount);
            Assert.Equal(199, ser.StringCount);
            Assert.Equal(975, ser.StringIdxCount);
        }

        [Fact]
        public void TestDeserializeType()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            var type = new SerialMoveset(ser);
            Assert.Equal(26, type.States.Count);
        }
    }
}