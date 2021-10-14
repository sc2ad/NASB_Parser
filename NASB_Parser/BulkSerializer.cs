using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NASB_Parser
{
    public class BulkSerializer
    {
        public BulkSerializer(Stream s)
        {
            using var reader = new StreamReader(s);
            Parse(reader);
        }

        public BulkSerializer(string data)
        {
            Parse(new StringReader(data));
        }

        public const string HeaderName = "BulkSerialize";
        public const string HeaderVersion = "VERSION_0";

        private List<int> intData;
        private List<float> floatData;
        private List<int> floatIdx;
        private List<string> stringData;
        private List<int> stringIdx;

        private static readonly NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;

        public int IntCount { get => intData.Count; }
        public int FloatCount { get => floatData.Count; }
        public int FloatIdxCount { get => floatIdx.Count; }
        public int StringCount { get => stringData.Count; }
        public int StringIdxCount { get => stringIdx.Count; }

        private void Parse(TextReader reader)
        {
            var header = reader.ReadLine();
            if (HeaderName != header)
                throw new InvalidOperationException($"Cannot parse serialization type: {header}!");
            header = reader.ReadLine();
            if (HeaderVersion != header)
                throw new InvalidOperationException($"Cannot parse serialization version: {header}!");
            var intDataSize = int.Parse(reader.ReadLine());
            intData = new List<int>(intDataSize);
            var floatDataSize = int.Parse(reader.ReadLine());
            floatData = new List<float>(floatDataSize);
            var floatIdxSize = int.Parse(reader.ReadLine());
            floatIdx = new List<int>(floatIdxSize);
            var stringDataSize = int.Parse(reader.ReadLine());
            stringData = new List<string>(stringDataSize);
            var stringIdxSize = int.Parse(reader.ReadLine());
            stringIdx = new List<int>(stringIdxSize);

            for (int i = 0; i < intDataSize; i++)
            {
                if (int.TryParse(reader.ReadLine(), out var dat))
                    intData.Add(dat);
                else
                    intData.Add(0);
            }
            for (int i = 0; i < floatDataSize; i++)
            {
                if (float.TryParse(reader.ReadLine(), NumberStyles.Any, invariantInfo, out var dat))
                    floatData.Add(dat);
                else
                    floatData.Add(0);
            }
            for (int i = 0; i < floatIdxSize; i++)
            {
                if (int.TryParse(reader.ReadLine(), out var dat))
                    floatIdx.Add(dat);
                else
                    floatIdx.Add(0);
            }
            for (int i = 0; i < stringDataSize; i++)
            {
                stringData.Add(reader.ReadLine().Replace('|', '\n'));
            }
            for (int i = 0; i < stringIdxSize; i++)
            {
                if (int.TryParse(reader.ReadLine(), out var dat))
                    stringIdx.Add(dat);
                else
                    stringIdx.Add(0);
            }
            // TODO: Check to ensure that we read everything?
        }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(HeaderName);
            writer.WriteLine(HeaderVersion);
            writer.WriteLine(intData.Count);
            writer.WriteLine(floatData.Count);
            writer.WriteLine(floatIdx.Count);
            writer.WriteLine(stringData.Count);
            writer.WriteLine(stringIdx.Count);
            foreach (var i in intData)
            {
                writer.WriteLine(i);
            }
            foreach (var f in floatData)
            {
                writer.WriteLine(f.ToString("R", invariantInfo));
            }
            foreach (var i in floatIdx)
            {
                writer.WriteLine(i);
            }
            foreach (var s in stringData)
            {
                writer.WriteLine(s);
            }
            foreach (var i in stringIdx)
            {
                writer.WriteLine(i);
            }
        }

        public void AddInt(int x)
        {
            intData.Add(x);
        }

        public void AddFloat(float x)
        {
            // TODO: Use an ordered lookup here to save time, for now this will do.
            int idx = floatData.FindIndex(f => f == x);
            if (idx >= 0)
            {
                floatIdx.Add(idx);
            }
            else
            {
                floatIdx.Add(floatData.Count);
                floatData.Add(x);
            }
        }

        public void AddString(string s)
        {
            s = s.Replace('\n', '|');
            // TODO: Use an ordered lookup here to save time, for now this will do.
            int idx = stringData.FindIndex(f => f == s);
            if (idx >= 0)
            {
                stringIdx.Add(idx);
            }
            else
            {
                stringIdx.Add(stringData.Count);
                stringData.Add(s);
            }
        }
    }
}