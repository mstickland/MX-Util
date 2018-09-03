using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public class UIOption : MatchSetUIOption
    {
        public UIOption(string title, Action<ICLICommand> selectFunc) :base(title)
        {
            SelectFunc = selectFunc;
            Triggers   = new[] {title};
        }
    }
}
