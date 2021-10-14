using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOrderedSensitive : StateAction
    {
        public List<StateAction> Actions { get; }

        public SAOrderedSensitive()
        {
            Actions = new List<StateAction>();
        }

        internal SAOrderedSensitive(BulkSerializer reader) : base(reader)
        {
            int len = reader.ReadInt();
            if (len >= 0)
            {
                Actions = new List<StateAction>(len);
                for (int i = 0; i < len; i++)
                {
                    Actions.Add(Read(reader));
                }
            }
            else
            {
                Actions = new List<StateAction>();
            }
        }
    }
}