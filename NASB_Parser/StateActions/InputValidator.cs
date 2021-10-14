using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class InputValidator
    {
        public ValidatorInputType InputType { get; set; }
        public bool RawX { get; set; }
        public CtrlSeg Segment { get; set; }
        public ValidatorFloatCompare FloatCompare { get; set; }
        public ValidatorButtonCompare ButtonCompare { get; set; }
        public CtrlSegCompare SegCompare { get; set; }
        public ValidatorMultiCompare MultiCompare { get; set; }
        public FloatSource FloatContainer { get; set; }
        public List<InputValidator> Validators { get; }

        public InputValidator()
        {
            Validators = new List<InputValidator>();
        }

        public InputValidator(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            InputType = (ValidatorInputType)reader.ReadInt();
            RawX = reader.ReadInt() > 0;
            Segment = (CtrlSeg)reader.ReadInt();
            FloatCompare = (ValidatorFloatCompare)reader.ReadInt();
            ButtonCompare = (ValidatorButtonCompare)reader.ReadInt();
            SegCompare = (CtrlSegCompare)reader.ReadInt();
            MultiCompare = (ValidatorMultiCompare)reader.ReadInt();
            FloatContainer = FloatSource.Read(reader);
            int sz = reader.ReadInt();
            if (sz < 0)
            {
                Validators = new List<InputValidator>();
            }
            else
            {
                Validators = new List<InputValidator>(sz);
                for (int i = 0; i < sz; i++)
                {
                    Validators.Add(new InputValidator(reader));
                }
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