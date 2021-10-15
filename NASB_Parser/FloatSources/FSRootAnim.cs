using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSRootAnim : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSRootAnim()
        {
        }

        internal FSRootAnim(BulkSerializer reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            RootRate,
            RootFrame
        }
    }
}