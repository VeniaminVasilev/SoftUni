namespace CommandPattern.Core.Commands
{
    public class SumCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            decimal firstNumber = decimal.Parse(args[0]);
            decimal secondNumber = decimal.Parse(args[1]);

            decimal sum = firstNumber + secondNumber;
            return sum.ToString();
        }
    }
}