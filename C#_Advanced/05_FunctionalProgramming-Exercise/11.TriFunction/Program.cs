namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ");

            Func<string, int> calculateNameSum = name => name.Sum(c => (int)c);

            Predicate<string> isMatchingName = name => calculateNameSum(name) >= targetSum;

            string result = names.FirstOrDefault(name => isMatchingName(name));

            Action<string> printer = x => Console.WriteLine(x);

            printer(result);
        }
    }
}