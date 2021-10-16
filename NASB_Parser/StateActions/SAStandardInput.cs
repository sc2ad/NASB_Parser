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

        internal SAStandardInput(BulkSerializeReader reader) : base(reader)
        {
            Frames = reader.ReadFloat();
            ForceCheck = reader.ReadBool();
            Config = new StandardConfig(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Frames);
            writer.Write(ForceCheck);
            writer.Write(Config);
        }

        public class StandardConfig : ISerializable
        {
            public byte DontCheck0 { get; set; }
            public byte DontCheck1 { get; set; }
            public byte DontCheck2 { get; set; }
            public byte DontCheck3 { get; set; }

            public StandardConfig()
            {
            }

            internal StandardConfig(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                DontCheck0 = (byte)reader.ReadInt();
                DontCheck1 = (byte)reader.ReadInt();
                DontCheck2 = (byte)reader.ReadInt();
                DontCheck3 = (byte)reader.ReadInt();
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(DontCheck0);
                writer.Write(DontCheck1);
                writer.Write(DontCheck2);
                writer.Write(DontCheck3);
            }
        }
    }
}