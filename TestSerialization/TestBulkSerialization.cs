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

        [Fact]
        public void TestRoundTrip()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(5495, ser.IntCount);
            Assert.Equal(67, ser.FloatCount);
            Assert.Equal(1461, ser.FloatIdxCount);
            Assert.Equal(199, ser.StringCount);
            Assert.Equal(975, ser.StringIdxCount);
            var writer = new BulkSerializeWriter();
            while (ser.NextInt < ser.IntCount)
            {
                writer.AddInt(ser.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                writer.AddFloat(ser.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                writer.AddString(ser.ReadString());
            }
            using var stream = new MemoryStream();
            using var innerS = new StreamWriter(stream);
            writer.Serialize(innerS);
            innerS.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var ser2 = new BulkSerializeReader(stream);
            Assert.Equal(5495, ser2.IntCount);
            Assert.Equal(67, ser2.FloatCount);
            Assert.Equal(1461, ser2.FloatIdxCount);
            Assert.Equal(199, ser2.StringCount);
            Assert.Equal(975, ser2.StringIdxCount);
            ser.Reset();
            while (ser.NextInt < ser.IntCount)
            {
                Assert.Equal(ser.ReadInt(), ser2.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                Assert.Equal(ser.ReadFloat(), ser2.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                Assert.Equal(ser.ReadString(), ser2.ReadString());
            }
        }

        [Fact]
        public void TestParseType()
        {
            var ser = new BulkSerializeReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(5495, ser.IntCount);
            Assert.Equal(67, ser.FloatCount);
            Assert.Equal(1461, ser.FloatIdxCount);
            Assert.Equal(199, ser.StringCount);
            Assert.Equal(975, ser.StringIdxCount);
            var typeInfo = new SerialMoveset(ser);
            var writer = new BulkSerializeWriter();
            typeInfo.Write(writer);
            Assert.Equal(5495, writer.IntCount);
            Assert.Equal(1461, writer.FloatCount);
            Assert.Equal(975, writer.StringCount);
            using var stream = new MemoryStream();
            using var innerS = new StreamWriter(stream);
            writer.Serialize(innerS);
            innerS.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var ser2 = new BulkSerializeReader(stream);
            Assert.Equal(5495, ser2.IntCount);
            Assert.Equal(67, ser2.FloatCount);
            Assert.Equal(1461, ser2.FloatIdxCount);
            Assert.Equal(199, ser2.StringCount);
            Assert.Equal(975, ser2.StringIdxCount);
            var typeInfo2 = new SerialMoveset(ser2);
            ser2.Reset();
            ser.Reset();
            while (ser.NextInt < ser.IntCount)
            {
                Assert.Equal(ser.ReadInt(), ser2.ReadInt());
            }
            while (ser.NextFloat < ser.FloatIdxCount)
            {
                Assert.Equal(ser.ReadFloat(), ser2.ReadFloat());
            }
            while (ser.NextString < ser.StringIdxCount)
            {
                Assert.Equal(ser.ReadString(), ser2.ReadString());
            }
            // TODO: Assert typeInfo and typeInfo2 are the same, for all members.
        }
    }
}