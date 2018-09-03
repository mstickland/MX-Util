using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public interface IUIOption
    {
        string Title { get; }
        bool IsMatch(ICLICommand command);
        void Select(ICLICommand command);
        bool Enabled {  get; set; }
    }
}
