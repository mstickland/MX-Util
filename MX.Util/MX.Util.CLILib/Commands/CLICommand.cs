using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.Commands
{
    public class CLICommand : ICLICommand
    {
        private const string UnknownCommand = "Unknown";

        public string OriginalCommandString { get; private set; }
        public string Command { get; }
        public IEnumerable<IParameter> Parameters => _parameters;
        public List<IParameter> _parameters;


        public CLICommand(string commandString)
        {
            OriginalCommandString = commandString;
            string[] tokens = GetTokens(commandString);
            Command = GetPrimaryCommand(tokens);
            _parameters = GetParameters(tokens);

        }

        private List<IParameter> GetParameters(string[] tokens)
        {
            return tokens.Skip(1).Select(t=>(IParameter)new Parameter(t,t)).ToList();
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
            return commandString.Split('"')
                                .SelectMany( (s, i) => i%2==0? s.Split(new[] {' ' }, StringSplitOptions.RemoveEmptyEntries) : new[] {s})
                                .ToArray();
        }

        public IParameter GetParameter(int i)
        {
            return _parameters.Skip(i).FirstOrDefault();
        }

        public IParameter GetParameter(string key)
        {
            return _parameters.FirstOrDefault(p => p.Key == key);
        }

        public bool HasParameter(int i)
        {
            return _parameters.Count <= i;
        }

        public bool HasParameter(string key)
        {
            return _parameters.Any(p => p.Key == key);
        }
    }
}
