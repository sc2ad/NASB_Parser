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
            var ser = new BulkSerializer(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            Assert.Equal(5495, ser.IntCount);
            Assert.Equal(67, ser.FloatCount);
            Assert.Equal(1461, ser.FloatIdxCount);
            Assert.Equal(199, ser.StringCount);
            Assert.Equal(975, ser.StringIdxCount);
        }

        [Fact]
        public void TestAddExisting()
        {
            var ser = new BulkSerializer(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            int knownInts = 5495, knownFloats = 67, knownFloatIdx = 1461, knownStrings = 199, knownStringIdx = 975;
            Assert.Equal(knownInts, ser.IntCount);
            Assert.Equal(knownFloats, ser.FloatCount);
            Assert.Equal(knownFloatIdx, ser.FloatIdxCount);
            Assert.Equal(knownStrings, ser.StringCount);
            Assert.Equal(knownStringIdx, ser.StringIdxCount);
            // Add existing properties
            ser.AddString("idle");
            ser.AddFloat(-1);
            // Only size differences should be idx
            Assert.Equal(knownInts, ser.IntCount);
            Assert.Equal(knownFloats, ser.FloatCount);
            Assert.Equal(knownFloatIdx + 1, ser.FloatIdxCount);
            Assert.Equal(knownStrings, ser.StringCount);
            Assert.Equal(knownStringIdx + 1, ser.StringIdxCount);
        }

        [Fact]
        public void TestAddUnique()
        {
            var ser = new BulkSerializer(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            int knownInts = 5495, knownFloats = 67, knownFloatIdx = 1461, knownStrings = 199, knownStringIdx = 975;
            Assert.Equal(knownInts, ser.IntCount);
            Assert.Equal(knownFloats, ser.FloatCount);
            Assert.Equal(knownFloatIdx, ser.FloatIdxCount);
            Assert.Equal(knownStrings, ser.StringCount);
            Assert.Equal(knownStringIdx, ser.StringIdxCount);
            // Add existing properties
            ser.AddString("idlealkdchjvajkfhgkjahgf");
            ser.AddFloat(1892748.8275f);
            ser.AddInt(1231541);
            // Only size differences should be idx
            Assert.Equal(knownInts + 1, ser.IntCount);
            Assert.Equal(knownFloats + 1, ser.FloatCount);
            Assert.Equal(knownFloatIdx + 1, ser.FloatIdxCount);
            Assert.Equal(knownStrings + 1, ser.StringCount);
            Assert.Equal(knownStringIdx + 1, ser.StringIdxCount);
        }

        [Fact]
        public void TestSerialize()
        {
            var ser = new BulkSerializer(Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSerialization.char_apple.txt"));
            var knownInts = ser.IntCount;
            var knownFloats = ser.FloatCount;
            var knownFloatIdx = ser.FloatIdxCount;
            var knownStrings = ser.StringCount;
            var knownStringIdx = ser.StringIdxCount;
            using (var fs = File.OpenWrite("test.txt"))
            {
                using var textWriter = new StreamWriter(fs);
                ser.Serialize(textWriter);
            }
            using (var fs = File.OpenRead("test.txt"))
                ser = new BulkSerializer(fs);
            Assert.Equal(knownInts, ser.IntCount);
            Assert.Equal(knownFloats, ser.FloatCount);
            Assert.Equal(knownFloatIdx, ser.FloatIdxCount);
            Assert.Equal(knownStrings, ser.StringCount);
            Assert.Equal(knownStringIdx, ser.StringIdxCount);
        }
    }
}