namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (characters.ContainsKey(text[i]))
                {
                    characters[text[i]]++;
                }
                else
                {
                    characters[text[i]] = 1;
                }
            }

            foreach (var character in characters)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}