using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{

    public interface IUIOptionCollection : IEnumerable<IUIOption>
    {
        IEnumerable<IUIOption> ActiveOptions { get; }
        IEnumerable<IUIOption> Options { get; }

        IUIOption this[string optionTitle] {  get; }

    }

}
