using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public enum GIEV
    {
        None,
        Unplugged,
        ActionFromFrame,
        SpecialFromFrame = 4,
        OffenseFromFrame = 8,
        DefenseFromFrame = 16,
        JumpFromFrame = 32,
        Grounded = 64
    }
}