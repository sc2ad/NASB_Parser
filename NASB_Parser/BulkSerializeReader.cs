using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NASB_Parser
{
    public class BulkSerializeReader
    {
        public BulkSerializeReader(Stream s)
        {
            using var reader = new StreamReader(s);
            Parse(reader);
        }

        public BulkSerializeReader(string data)
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

        public int IntCount { get => intData.Count; }
        public int FloatCount { get => floatData.Count; }
        public int FloatIdxCount { get => floatIdx.Count; }
        public int StringCount { get => stringData.Count; }
        public int StringIdxCount { get => stringIdx.Count; }

        private void Parse(TextReader reader)
        {
            var header = reader.ReadLine();
            if (HeaderName != header)
                throw new ReadException(this, $"Cannot parse serialization type: {header}!");
            header = reader.ReadLine();
            if (HeaderVersion != header)
                throw new ReadException(this, $"Cannot parse serialization version: {header}!");
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
                if (float.TryParse(reader.ReadLine(), NumberStyles.Any, Util.invariantInfo, out var dat))
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

        private int nextInt;

        public int NextInt
        {
            get => nextInt;
            set => nextInt = value <= intData.Count ? value :
                throw new IndexOutOfRangeException($"Cannot assign {nameof(NextInt)} to a value greater than the length of the int data!");
        }

        private int nextFloat;

        public int NextFloat
        {
            get => nextFloat;
            set => nextFloat = value <= floatIdx.Count ? value :
                throw new IndexOutOfRangeException($"Cannot assign {nameof(NextFloat)} to a value greater than the length of the float index data!");
        }

        private int nextString;

        public int NextString
        {
            get => nextString;
            set => nextString = value <= stringIdx.Count ? value :
                throw new IndexOutOfRangeException($"Cannot assign {nameof(NextString)} to a value greater than the length of the string index data!");
        }

        public int ReadIdStateCount()
        {
            Reset();
            // Game code: GetNextInt(), return GetNextInt()
            _ = ReadInt();
            return ReadInt();
        }

        public int ReadInt()
        {
            return intData[NextInt++];
        }

        public bool ReadBool()
        {
            return ReadInt() > 0;
        }

        public float ReadFloat()
        {
            return floatData[floatIdx[NextFloat++]];
        }

        public string ReadString()
        {
            return stringData[stringIdx[NextString++]];
        }

        public List<T> ReadList<T>(Func<BulkSerializeReader, T> initializer)
        {
            var lst = new List<T>();
            int sz = ReadInt();
            if (sz > 0)
            {
                lst.Capacity = sz;
                for (int i = 0; i < sz; i++)
                {
                    lst.Add(initializer(this));
                }
            }
            else if (sz < 0)
            {
                throw new ReadException(this, $"Invalid size for array: {sz}");
            }
            return lst;
        }

        public void Reset()
        {
            NextInt = 0;
            NextFloat = 0;
            NextString = 0;
        }

        public int PeekInt()
        {
            return intData[NextInt];
        }

        public float PeekFloat()
        {
            return floatData[floatIdx[NextFloat]];
        }

        public string PeekString()
        {
            return stringData[stringIdx[NextString]];
        }
    }
}