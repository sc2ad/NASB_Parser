using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSSports : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSSports()
        {
        }

        internal FSSports(BulkSerializeReader reader) : base(reader)
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