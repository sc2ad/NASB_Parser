using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace NASB_Parser
{
    public class BulkSerializeWriter
    {
        private readonly List<int> ints = new List<int>();
        private readonly List<float> floats = new List<float>();
        private readonly List<string> strings = new List<string>();

        public const string HeaderName = "BulkSerialize";
        public const string HeaderVersion = "VERSION_0";

        public BulkSerializeWriter()
        {
        }

        public void AddInt(int x)
        {
            ints.Add(x);
        }

        public void AddFloat(float x)
        {
            floats.Add(x);
        }

        public void AddString(string x)
        {
            strings.Add(x);
        }

        public void Write(int x)
        {
            AddInt(x);
        }

        public void Write(float x)
        {
            AddFloat(x);
        }

        public void Write(string x)
        {
            AddString(x);
        }

        public void Write(bool x)
        {
            // Yes, this is how they write bools.
            AddInt(x ? 7 : 0);
        }

        public void Write<T>(T ser) where T : class, ISerializable, new()
        {
            if (ser is null)
                ser = new T();
            ser.Write(this);
        }

        public void Write<T>(List<T> lst) where T : ISerializable
        {
            AddInt(lst.Count);
            foreach (var item in lst)
            {
                item.Write(this);
            }
        }

        public void Write(List<int> lst)
        {
            AddInt(lst.Count);
            foreach (var item in lst)
            {
                AddInt(item);
            }
        }

        public void Write(List<float> lst)
        {
            AddInt(lst.Count);
            foreach (var item in lst)
            {
                AddFloat(item);
            }
        }

        public void Write(List<string> lst)
        {
            AddInt(lst.Count);
            foreach (var item in lst)
            {
                AddString(item);
            }
        }

        public void Write(List<bool> lst)
        {
            AddInt(lst.Count);
            foreach (var item in lst)
            {
                Write(item);
            }
        }

        public void Serialize(TextWriter writer)
        {
            writer.WriteLine(HeaderName);
            writer.WriteLine(HeaderVersion);
            // Process floats and strings
            var floatData = new OrderedDictionary(floats.Count);
            List<int> floatIdx = new List<int>(floats.Count);
            int idx = 0;
            foreach (var f in floats)
            {
                if (floatData.Contains(f))
                {
                    floatIdx.Add((int)floatData[f]);
                }
                else
                {
                    floatData.Add(f, idx);
                    floatIdx.Add(idx);
                    idx++;
                }
            }
            var stringData = new OrderedDictionary(strings.Count);
            List<int> stringIdx = new List<int>(strings.Count);
            idx = 0;
            foreach (var s in strings)
            {
                if (stringData.Contains(s))
                {
                    stringIdx.Add((int)stringData[s]);
                }
                else
                {
                    stringData.Add(s, idx);
                    stringIdx.Add(idx);
                    idx++;
                }
            }

            writer.WriteLine(ints.Count);
            writer.WriteLine(floatData.Keys.Count);
            writer.WriteLine(floatIdx.Count);
            writer.WriteLine(stringData.Keys.Count);
            writer.WriteLine(stringIdx.Count);
            foreach (var i in ints)
            {
                writer.WriteLine(i);
            }
            foreach (var f in floatData.Keys)
            {
                writer.WriteLine(((float)f).ToString("R", Util.invariantInfo));
            }
            foreach (var fi in floatIdx)
            {
                writer.WriteLine(fi);
            }
            foreach (var s in stringData.Keys)
            {
                writer.WriteLine(((string)s).Replace('\n', '|'));
            }
            foreach (var si in stringIdx)
            {
                writer.WriteLine(si);
            }
        }
    }
}