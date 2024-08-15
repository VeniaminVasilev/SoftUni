namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> predicate = name => name.Length <= n;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(name => predicate(name))));
        }
    }
}