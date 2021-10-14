using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CheckThing
    {
        public CheckThing()
        {
        }

        internal CheckThing(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
        }

        public static CheckThing Read(BulkSerializer reader)
        {
            return (TypeId)reader.ReadInt() switch
            {
                TypeId.MultipleId => new CTMultiple(reader),
                TypeId.CompareId => new CTCompareFloat(reader),
                TypeId.DoubleTapId => new CTDoubleTapId(reader),
                TypeId.InputId => new CTInput(reader),
                TypeId.InputSeriesId => new CTInputSeries(reader),
                TypeId.TechId => new CTCheckTech(reader),
                TypeId.GrabId => new CTGrabId(reader),
                TypeId.GrabAgentId => new CTGrabbedAgent(reader),
                TypeId.SkinId => new CTSkin(reader),
                TypeId.MoveId => new CTMoveId(reader),
                _ => new CheckThing(reader),
            };
        }

        public enum TypeId
        {
            BaseIdentifier,
            MultipleId,
            CompareId,
            DoubleTapId,
            InputId,
            InputSeriesId,
            TechId,
            GrabId,
            GrabAgentId,
            SkinId,
            MoveId
        }

        public enum CheckWay
        {
            Equal,
            NotEqual,
            Less,
            Larger,
            EOLess,
            EOLarger
        }
    }
}