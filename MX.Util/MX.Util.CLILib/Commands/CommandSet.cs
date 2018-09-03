using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.Commands
{
    internal interface ICommandSet<TResult>
    {
        bool IsMatch(ICLICommand command);
        Func<ICLICommand, TResult> Action { get; set; }
    }

    internal class MatchSetCommandSet<TResult> : ICommandSet<TResult>
    {
        public IEnumerable<string> TriggerCommands { get; set; }
        public Func<ICLICommand, TResult> Action { get; set; }

        public bool IsMatch(ICLICommand command)
        {
            return TriggerCommands.Any(c => String.Equals(c, command.Command, StringComparison.OrdinalIgnoreCase));
        }
    }

    internal class MatchFuncCommandSet<TResult> : ICommandSet<TResult>
    {
        public Func<string, bool> MatchFunc {  get; set; }
        public Func<ICLICommand, TResult> Action { get; set; }

        public MatchFuncCommandSet(Func<string, bool> func, Func<ICLICommand, TResult> action)
        {
            MatchFunc = func;
            Action    = action;
        }

        public bool IsMatch(ICLICommand command)
        {
            return MatchFunc(command.Command);
        }
    }

    internal class CommandMatchFuncCommandSet<TResult> : ICommandSet<TResult>
    {
        public Func<ICLICommand, bool> MatchFunc { get; set; }
        public Func<ICLICommand, TResult> Action { get; set; }

        public CommandMatchFuncCommandSet(Func<ICLICommand, bool> func, Func<ICLICommand, TResult> action)
        {
            MatchFunc = func;
            Action    = action;
        }

        public bool IsMatch(ICLICommand command)
        {
            return MatchFunc(command);
        }
    }
}
