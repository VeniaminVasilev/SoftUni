namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsFiltered = Console.ReadLine()
                .Split(" ")
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            foreach (string word in wordsFiltered)
            {
                Console.WriteLine(word);
            }
        }
    }
}