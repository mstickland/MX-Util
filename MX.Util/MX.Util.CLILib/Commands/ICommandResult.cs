namespace MX.Util.CLILib.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        bool EndProcessing {  get; set; }
    }
}