using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public class UIFullDelegateOption : UISelectDelegateOption
    {
        private string _title;
        public override string Title => _title;
        public override string CleanTitle => _title;
        public Func<ICLICommand, bool> MatchDelegate { get; internal set; }

        public UIFullDelegateOption(string title) => _title = title;

        public override bool IsMatch(ICLICommand command) 
        {
            if(MatchDelegate == null)
                throw new InvalidOperationException("Match delegate cannot be null");
            return MatchDelegate(command);
        }
    }
}
