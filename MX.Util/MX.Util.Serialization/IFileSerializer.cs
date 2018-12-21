using System;
using System.Collections.Generic;
using System.Text;

namespace MX.Util.Serialization
{
    public interface IFileSerializer<TSerialized>
    {
        void SaveToFile(TSerialized t, string filename);
        TSerialized LoadFromFile(string filename);
    }
}
