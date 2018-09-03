using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.Commands
{
    /// <summary>
    /// in progress
    /// </summary>

    internal class DictionaryCLICommand : ICLICommand
    {
        private const string UnknownCommand = "Unknown";

        public string OriginalCommandString { get; private set; }
        public string Command { get; }
        public IEnumerable<IParameter> Parameters => _parameters.Select(kvp => kvp.Value);
        public Dictionary<string, IParameter> _parameters;


        public DictionaryCLICommand(string commandString)
        {
            OriginalCommandString = commandString;
            string[] tokens = GetTokens(commandString);
            Command = GetPrimaryCommand(tokens);
            _parameters = GetParameters(tokens);

        }

        private Dictionary<string, IParameter> GetParameters(string[] tokens)
        {
            return tokens.Skip(1).ToDictionary(t => t, t => (IParameter)new Parameter(t, t));
        }

        private string GetPrimaryCommand(string[] tokens)
        {
            if (tokens.Length == 0)
                return UnknownCommand;
            return tokens[0];
        }

        private string[] GetTokens(string commandString)
        {
            if (String.IsNullOrEmpty(commandString))
                return new string[] { };
            return commandString.Split(' ');
        }

        public IParameter GetParameter(int i)
        {
            return _parameters.Skip(i).FirstOrDefault().Value;
        }

        public IParameter GetParameter(string key)
        {
            return _parameters.TryGetValue(key, out IParameter param) ? param : null;
        }

        public bool HasParameter(int i)
        {
            return _parameters.Count <= i;
        }

        public bool HasParameter(string key)
        {
            return _parameters.ContainsKey(key);
        }
    }
}
