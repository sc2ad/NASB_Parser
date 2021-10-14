using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSInput : FloatSource
    {
        public CheckInput Input { get; set; }

        public FSInput()
        {
        }

        internal FSInput(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Input = (CheckInput)reader.ReadInt();
        }

        public enum CheckInput
        {
            CtrlX,
            CtrlXRaw,
            CtrlY,
            Attack,
            Strong,
            Special,
            Jump,
            Defend,
            Fun,
            Grabmacro
        }
    }
}