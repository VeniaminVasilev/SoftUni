using System;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(exitCode: 0);
            return string.Empty;
        }
    }
}