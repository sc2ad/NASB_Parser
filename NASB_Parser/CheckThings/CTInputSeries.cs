using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTInputSeries : CheckThing
    {
        public int CheckFrames { get; set; }
        public List<LookForInput> InputSeries { get; } = new List<LookForInput>();
        public List<LookForInput> StopLooking { get; } = new List<LookForInput>();

        public CTInputSeries()
        {
        }

        internal CTInputSeries(BulkSerializer reader) : base(reader)
        {
            CheckFrames = reader.ReadInt();
            InputSeries = reader.ReadList(r => new LookForInput(r));
            StopLooking = reader.ReadList(r => new LookForInput(r));
        }
    }
}