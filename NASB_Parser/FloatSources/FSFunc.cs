using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSFunc : FloatSource
    {
        public FuncWay Way { get; set; }
        public FloatSource ContainerA { get; set; }
        public FloatSource ContainerB { get; set; }
        public FloatSource ContainerC { get; set; }

        public FSFunc()
        {
        }

        internal FSFunc(BulkSerializeReader reader) : base(reader)
        {
            Way = (FuncWay)reader.ReadInt();
            ContainerA = Read(reader);
            ContainerB = Read(reader);
            ContainerC = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Way);
            writer.Write(ContainerA);
            writer.Write(ContainerB);
            writer.Write(ContainerC);
        }

        public enum FuncWay
        {
            Abs,
            Add,
            Sub,
            Div,
            Mult,
            Sin,
            Cos,
            Mod,
            Clamp,
            Floor,
            Ceil,
            MoveTo,
            MoveToAng,
            MoveToF,
            MoveToAngF,
            Sign,
            Lerp,
            InvLerp,
            Repeat,
            Pow,
            Sqrt,
            Log,
            Log10,
            Atan,
            Atan2,
            RoundToInt,
            Max,
            Min,
            Pi
        }
    }
}