using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStandardInput : StateAction
    {
        public float Frames { get; set; }
        public bool ForceCheck { get; set; }
        public StandardConfig Config { get; set; }

        public SAStandardInput()
        {
        }

        internal SAStandardInput(BulkSerializer reader) : base(reader)
        {
            Frames = reader.ReadFloat();
            ForceCheck = reader.ReadBool();
            Config = new StandardConfig(reader);
        }

        public class StandardConfig
        {
            public byte DontCheck0 { get; set; }
            public byte DontCheck1 { get; set; }
            public byte DontCheck2 { get; set; }
            public byte DontCheck3 { get; set; }

            public StandardConfig()
            {
            }

            internal StandardConfig(BulkSerializer reader)
            {
                _ = reader.ReadInt();
                DontCheck0 = (byte)reader.ReadInt();
                DontCheck1 = (byte)reader.ReadInt();
                DontCheck2 = (byte)reader.ReadInt();
                DontCheck3 = (byte)reader.ReadInt();
            }
        }
    }
}