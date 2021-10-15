using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSSports : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSSports()
        {
        }

        internal FSSports(BulkSerializer reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public enum Attributes
        {
            ActiveBall,
            BounceOnGoalEdge,
            GoalScore,
            RespawnBall,
            InheritPush,
            LastBallPushX,
            LastBallPushY
        }
    }
}