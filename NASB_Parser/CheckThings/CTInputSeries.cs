using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTInputSeries : CheckThing
    {
        public int CheckFrames { get; set; }
        public List<LookForInput> InputSeries { get; }
        public List<LookForInput> StopLooking { get; }

        public CTInputSeries()
        {
            InputSeries = new List<LookForInput>();
            StopLooking = new List<LookForInput>();
        }

        internal CTInputSeries(BulkSerializer reader) : base(reader)
        {
            CheckFrames = reader.ReadInt();
            int len = reader.ReadInt();
            if (len > 0)
            {
                InputSeries = new List<LookForInput>(len);
                for (int i = 0; i < len; i++)
                {
                    InputSeries.Add(new LookForInput(reader));
                }
            }
            else
            {
                InputSeries = new List<LookForInput>();
            }
            len = reader.ReadInt();
            if (len > 0)
            {
                StopLooking = new List<LookForInput>(len);
                for (int i = 0; i < len; i++)
                {
                    StopLooking.Add(new LookForInput(reader));
                }
            }
            else
            {
                StopLooking = new List<LookForInput>();
            }
        }
    }
}