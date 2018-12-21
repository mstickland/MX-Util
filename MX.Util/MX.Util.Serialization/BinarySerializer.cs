using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MX.Util.Serialization
{
    public class BinarySerializer<TSerialized> : IFileSerializer<TSerialized>, ISerializer<TSerialized>
    {

        public void SaveToFile(TSerialized t, string filename)
        {
            
            using(var stream = File.Create(filename))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
            }
                        
        }

        public TSerialized LoadFromFile(string filename)
        {

            using(FileStream stream = File.OpenRead(filename))
            {
                var formatter = new BinaryFormatter();
                var deserialized = (TSerialized)formatter.Deserialize(stream);
                return deserialized;
            }

            
        }

    }
}
