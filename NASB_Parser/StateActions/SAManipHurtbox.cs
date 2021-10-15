using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAManipHurtbox : StateAction
    {
        public List<HBM> Manips { get; }

        public SAManipHurtbox()
        {
            Manips = new List<HBM>();
        }

        internal SAManipHurtbox(BulkSerializer reader) : base(reader)
        {
            int len = reader.ReadInt();
            if (len > 0)
            {
                Manips = new List<HBM>(len);
                for (int i = 0; i < len; i++)
                {
                    Manips.Add(new HBM(reader));
                }
            }
            else
            {
                Manips = new List<HBM>();
            }
        }

        public enum Manip
        {
            Radius,
            Type,
            Armor,
            Kbarmor,
            WorldOffsetX,
            WorldOffsetY,
            WorldOffsetZ,
            LocalOffsetX,
            LocalOffsetY,
            LocalOffsetZ,
            WorldOffsetX2nd,
            WorldOffsetY2nd,
            WorldOffsetZ2nd,
            LocalOffsetX2nd,
            LocalOffsetY2nd,
            LocalOffsetZ2nd
        }

        public class HBM
        {
            public Manip Manip { get; set; }
            public int Hurtbox { get; set; }
            public HurtType Type { get; set; }
            public FloatSource Source { get; set; }

            public HBM()
            {
            }

            internal HBM(BulkSerializer reader)
            {
                _ = reader.ReadInt();
                Manip = (Manip)reader.ReadInt();
                Hurtbox = reader.ReadInt();
                Type = (HurtType)reader.ReadInt();
                Source = FloatSource.Read(reader);
            }
        }
    }
}