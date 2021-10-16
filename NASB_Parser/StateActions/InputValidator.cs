using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class InputValidator : ISerializable
    {
        public ValidatorInputType InputType { get; set; }
        public bool RawX { get; set; }
        public CtrlSeg Segment { get; set; }
        public ValidatorFloatCompare FloatCompare { get; set; }
        public ValidatorButtonCompare ButtonCompare { get; set; }
        public CtrlSegCompare SegCompare { get; set; }
        public ValidatorMultiCompare MultiCompare { get; set; }
        public FloatSource FloatContainer { get; set; }
        public List<InputValidator> Validators { get; private set; } = new List<InputValidator>();

        public InputValidator()
        {
        }

        public InputValidator(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            InputType = (ValidatorInputType)reader.ReadInt();
            RawX = reader.ReadBool();
            Segment = (CtrlSeg)reader.ReadInt();
            FloatCompare = (ValidatorFloatCompare)reader.ReadInt();
            ButtonCompare = (ValidatorButtonCompare)reader.ReadInt();
            SegCompare = (CtrlSegCompare)reader.ReadInt();
            MultiCompare = (ValidatorMultiCompare)reader.ReadInt();
            FloatContainer = FloatSource.Read(reader);
            int len = reader.ReadInt();
            if (len > 0)
            {
                Validators = new List<InputValidator>(len);
                for (int i = 0; i < len; i++)
                {
                    Validators.Add(new InputValidator(reader));
                }
            }
            else if (len < -1)
            {
                throw new ReadException(reader, $"Cannot create an {nameof(InputValidator)} collection with length: {len}!");
            }
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(InputType);
            writer.Write(RawX);
            writer.Write(Segment);
            writer.Write(FloatCompare);
            writer.Write(ButtonCompare);
            writer.Write(SegCompare);
            writer.Write(MultiCompare);
            writer.Write(FloatContainer);
            if (InputType != ValidatorInputType.MultiValid)
            {
                writer.Write(-1);
            }
            else
            {
                writer.Write(Validators);
            }
        }

        public enum ValidatorInputType
        {
            MultiValid,
            CtrlMag,
            CtrlX,
            CtrlY,
            CtrlSegment,
            CtrlMoveX,
            CtrlMoveY,
            Tilting,
            Attack,
            StrAtk,
            Special,
            Jump,
            Defend,
            Fun,
            GrabMacro,
            Taunt = 16,
            CPU = 15
        }

        public enum CtrlSeg
        {
            Neutral = 1,
            Up,
            Down = 4,
            Right = 8,
            Left = 16,
            UpRight = 32,
            UpLeft = 64,
            DownRight = 128,
            DownLeft = 256
        }

        public enum ValidatorFloatCompare
        {
            Equal,
            Larger,
            Smaller,
            EOLarger,
            EOSmaller,
            Not,
            PassedBy,
            PrevValue
        }

        public enum ValidatorButtonCompare
        {
            Not,
            Up,
            Down,
            Held,
            NotOrUp,
            DownOrHeld
        }

        public enum CtrlSegCompare
        {
            Outside = 1,
            Inside,
            Entered = 4,
            Exited = 8
        }

        public enum ValidatorMultiCompare
        {
            All,
            Any,
            One,
            None
        }
    }
}