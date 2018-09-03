using MX.Util.CLILib.Commands;
using MX.Util.CLILib.UIOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib
{

    public class CommandEvent
    {
        public ICLICommand Command { get; internal set; }
        /// <summary>
        /// Null if no option found
        /// </summary>
        public IUIOption Option { get; private set; }

        internal CommandEvent() { }
        internal CommandEvent( ICLICommand command, IUIOption opt)
        {            
            Command = command;
            Option  = opt;
        }
    }

    public enum ProcessorMode
    {
        ReadLines,
        ReadKey,
    }

    public class CLIProcessor
    {
        
        protected event EventHandler<CommandEvent> _onSuccess;
        public ProcessorMode Mode {  get; set; } = ProcessorMode.ReadLines;
        private Dictionary<ProcessorMode, Func<string>> _readInputDelegates = new Dictionary<ProcessorMode, Func<string>>()
        {
            [ProcessorMode.ReadLines] = Console.ReadLine,
            [ProcessorMode.ReadKey]   = () => Console.ReadKey().KeyChar.ToString(),
        };

        public event EventHandler<CommandEvent> OnCommandProcessed 
        { 
            add { _onSuccess += value; }
            remove { _onSuccess -= value; } 
        }

        private event EventHandler<CommandEvent> _onUnknown;
        public event EventHandler<CommandEvent> OnUnknownCommand 
        {
            add { _onUnknown += value; }
            remove { _onUnknown -= value; }
        }

        protected bool _run = false;

        public bool IsRunning => _run;

        public IUIOptionCollection OptionCollection { get; set; }

        public CLIProcessor()
        {

        }

        public CLIProcessor(ProcessorMode mode)
        {
            Mode = mode;
        }

        public void Start()
        {
            _run = true;
            Run();
        }

        private void Run()
        {
            while(_run)
            {
                string inputString  = _readInputDelegates[Mode]();
                ICLICommand command = new CLICommand(inputString);
                IUIOption option= FindOption(command);                

                if (option != null)
                {
                    option.Select(command);
                    _onSuccess?.Invoke(this, new CommandEvent(command, option));
                }                    
                else
                    _onUnknown?.Invoke(this, new CommandEvent(command, option));

            }

        }        

        internal IUIOption FindOption(ICLICommand command)
        {
            
            if (OptionCollection == null)
                throw new InvalidOperationException($"{nameof(OptionCollection)} cannot be null while processing options.");

            //tolist prevents potential errors from editing the list
            foreach(var option in OptionCollection.ActiveOptions.ToList())
            {
                if(option.IsMatch(command)) 
                    return option;
            }
            return null;
        }

        public void Stop()
        {
            _run = false;
        }


        

    }
}
