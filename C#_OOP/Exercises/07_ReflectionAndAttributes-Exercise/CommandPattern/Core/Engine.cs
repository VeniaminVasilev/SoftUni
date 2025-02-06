using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter ??
                throw new ArgumentNullException(nameof(commandInterpreter));
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string output = this._commandInterpreter.Read(input);
                Console.WriteLine(output);
            }
        }
    }
}