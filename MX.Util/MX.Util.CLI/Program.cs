using MX.Util.CLILib;
using MX.Util.CLILib.Commands;
using MX.Util.CLILib.UIOptions;
using MX.Util.CLILib.UIOptions.AutoOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MX.Util.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start program
            new Program().Start();
        }

        private string _message = String.Empty;
        IUIOptionCollection _options;

        private void Start()
        {
            //Setup cli command processor
            CLIProcessor processor = SetupProcessor();
            
            //Setup which options we want users to be able to enter
            _options = SetupOptions(processor);
            
            //assign options to the processor
            processor.OptionCollection = _options;
            
            PromptUser(_options);
            //Starts the cli processor. Will cause the program to enter a repeating loop that waits for user input
            //You can exit this loop by calling processor.Stop()
            processor.Start();
        }

        private CLIProcessor SetupProcessor()
        {
            var processor = new CLIProcessor(ProcessorMode.ReadKey);

            processor.OnUnknownCommand   += (s, ev) => Console.WriteLine($"\rCommand not understood: {ev.Command.Command}");
            processor.OnCommandProcessed += (s, ev) =>  {
                Console.Clear();
                Console.WriteLine(ev.Option.Title);
                PromptUser(_options);
            };

            return processor;
        }

        private void PromptUser(IUIOptionCollection options)
        {            
            Console.WriteLine("Select:");
            foreach (var opt in options.Options)
                Console.WriteLine(opt.Title);
        }


        private IUIOptionCollection SetupOptions(CLIProcessor processor)
        {
            AutoUIOptionCollection options = new AutoUIOptionCollection();

            var optTitles = new[] { "Walk", "Amble", "Wander", "Saunter", "Run"};
            
            foreach(var title in optTitles)
                options.Add(title, c => _message = c.Command);

            options.Add("Exit",  'x',  c => processor.Stop());
            
            return options;
        }
        
    }
}
