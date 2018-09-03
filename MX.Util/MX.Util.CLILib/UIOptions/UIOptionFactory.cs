using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public class UIOptionFactory
    {
        public IUIOption Create(string title, IEnumerable<string> triggers, Action<ICLICommand> selectFunc)
        {
            if(selectFunc == null)
                throw new ArgumentNullException($"{nameof(selectFunc)} cannot be null.");

            return new MatchSetUIOption(title ?? String.Empty) 
            {
                Triggers   = triggers ?? Enumerable.Empty<string>(),
                SelectFunc = selectFunc,                
            };
        }

        public IUIOption Create(IEnumerable<string> triggers, Action<ICLICommand> selectFunc)
        {
            return Create(triggers.FirstOrDefault() ?? String.Empty, triggers, selectFunc);
        }

        public IUIOption Create(string title, Func<ICLICommand, bool> matchFunc, Action<ICLICommand> selectFunc)
        {
            if (selectFunc == null)
                throw new ArgumentNullException($"{nameof(selectFunc)} cannot be null.");
            if (matchFunc == null)
                throw new ArgumentNullException($"{nameof(selectFunc)} cannot be null.");

            return new UIFullDelegateOption(title ?? String.Empty)
            {
                MatchDelegate = matchFunc, 
                SelectFunc    = selectFunc,
            };
        }

        public IUIOption Create(Func<ICLICommand, bool> matchFunc, Action<ICLICommand> selectFunc)
        {
            return Create(String.Empty, matchFunc, selectFunc);
        }
    }
}
