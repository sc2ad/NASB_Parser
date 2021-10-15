using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public interface ISerializable
    {
        void Write(BulkSerializeWriter writer);
    }
}