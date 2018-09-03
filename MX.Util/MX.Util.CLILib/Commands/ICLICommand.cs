using System.Collections.Generic;

namespace MX.Util.CLILib
{
    public interface ICLICommand
    {
        string Command { get; }
        string OriginalCommandString { get; }
        IEnumerable<IParameter> Parameters { get; }
        IParameter GetParameter(int i);
        IParameter GetParameter(string key);
        bool HasParameter(int i);
        bool HasParameter(string key);
    }
}