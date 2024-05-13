namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string keyword = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(keyword))
                {
                    words[keyword].Add(synonym);
                }
                else
                {
                    words[keyword] = new List<string>();
                    words[keyword].Add(synonym);
                }
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}