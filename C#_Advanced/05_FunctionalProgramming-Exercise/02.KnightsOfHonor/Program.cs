namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printer = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(name => $"Sir " + name)));

            printer(names);
        }
    }
}