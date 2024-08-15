namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine()
                .Split()
                .ToList();

            Action<List<string>> printer = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            printer(strings);
        }
    }
}