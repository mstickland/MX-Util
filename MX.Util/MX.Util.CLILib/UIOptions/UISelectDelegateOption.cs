using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public abstract class UISelectDelegateOption : IUIOption
    {
        public bool Enabled {  get; set; } = true;
        public abstract string Title { get; }
        public Action<ICLICommand> SelectFunc { get; protected internal set; }

        public abstract bool IsMatch(ICLICommand command);
        public void Select(ICLICommand command) => SelectFunc?.Invoke(command);


    }
}
