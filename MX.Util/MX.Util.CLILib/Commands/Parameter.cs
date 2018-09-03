using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib
{
    public class Parameter : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Parameter(string key, string value)
        {
            Key   = key;
            Value = value;
        }
    }
}
