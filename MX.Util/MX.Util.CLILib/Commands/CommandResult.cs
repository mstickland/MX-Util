using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success {  get; set; } = true;
        public bool EndProcessing { get; set; }
        public string Response {  get; set; } = String.Empty;

        public static CommandResult End => new CommandResult() {  EndProcessing = true };

        public CommandResult()
        {
            
        }

        public CommandResult(bool success)
        {
            Success = success;
        }

        public CommandResult(bool success, string response)
        {
            Success  = success;
            Response = response;
        }

        public CommandResult(string response)
        {
            Response = response;
        }
    }
}
