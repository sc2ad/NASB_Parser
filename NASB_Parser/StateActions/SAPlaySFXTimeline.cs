using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAPlaySFXTimeline : StateAction
    {
        public ManipType Manip { get; set; }
        public bool Loop { get; set; }
        public FloatSource Source { get; set; }
        public string Timeline { get; set; }

        public SAPlaySFXTimeline()
        {
        }

        internal SAPlaySFXTimeline(BulkSerializer reader) : base(reader)
        {
            Manip = (ManipType)reader.ReadInt();
            Loop = reader.ReadBool();
            Source = FloatSource.Read(reader);
            Timeline = reader.ReadString();
        }

        public enum ManipType
        {
            Play,
            Rate,
            Position
        }
    }
}