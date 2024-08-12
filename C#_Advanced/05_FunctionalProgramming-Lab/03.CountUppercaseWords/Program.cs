namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> startsWithUppercase = word => !string.IsNullOrEmpty(word) && char.IsUpper(word[0]);

            List<string> words = Console.ReadLine().Split(" ").Where(startsWithUppercase).ToList();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}