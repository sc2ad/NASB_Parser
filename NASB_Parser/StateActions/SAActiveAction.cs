using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAActiveAction : StateAction
    {
        public StateAction Action { get; set; }
        public FloatSource FloatSource { get; set; }
        public string Id { get; set; }
        public Phases Phase { get; set; }

        public SAActiveAction()
        {
        }

        internal SAActiveAction(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
            FloatSource = FloatSource.Read(reader);
            Id = reader.ReadString();
            Phase = (Phases)reader.ReadInt();
        }

        public enum Phases
        {
            PreInputTrigger,
            PreStateUpd,
            PostStateUpd,
            PostAnimUpd
        }
    }
}