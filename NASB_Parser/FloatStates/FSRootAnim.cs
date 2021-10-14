using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSRootAnim : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSRootAnim()
        {
        }

        internal FSRootAnim(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            RootRate,
            RootFrame
        }
    }
}