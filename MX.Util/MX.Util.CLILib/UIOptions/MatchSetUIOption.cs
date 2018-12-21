using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public class MatchSetUIOption : UISelectDelegateOption
    {
        private string _title;
        public override string Title => _title;
        public override string CleanTitle => _title;
        public IEnumerable<string> Triggers {  get; internal set;}

        //TODO: public version? Triggers needs to be set. Or default in return
        internal MatchSetUIOption(string title) => _title = title;
        public override bool IsMatch(ICLICommand command) => Triggers.Any(t => t == command.Command);                
    }
}
