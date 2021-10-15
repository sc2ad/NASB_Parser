using NASB_Parser.FloatStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAManipHitbox : StateAction
    {
        public List<HBM> Manips { get; }

        public SAManipHitbox()
        {
            Manips = new List<HBM>();
        }

        internal SAManipHitbox(BulkSerializer reader) : base(reader)
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
            InteractWithHurtsets,
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
            public int Hitbox { get; set; }
            public FloatSource Source { get; set; }

            public HBM()
            {
            }

            internal HBM(BulkSerializer reader)
            {
                _ = reader.ReadInt();
                Manip = (Manip)reader.ReadInt();
                Hitbox = reader.ReadInt();
                Source = FloatSource.Read(reader);
            }
        }
    }
}