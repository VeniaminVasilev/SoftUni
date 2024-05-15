namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ").ToArray();
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string bannedWord = bannedWords[i];
                char character = '*';
                string replacement = new string(character, bannedWord.Length);
                while (true)
                {
                    int indexOfBannedWord = text.IndexOf(bannedWord);
                    if (indexOfBannedWord < 0) { break; }
                    text = text.Replace(bannedWord, replacement);
                }
            }
            Console.WriteLine(text);
        }
    }
}