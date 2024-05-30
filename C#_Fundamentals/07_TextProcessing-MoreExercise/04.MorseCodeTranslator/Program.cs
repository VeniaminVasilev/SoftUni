using System.Text;

namespace _04.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseCodes = new Dictionary<string, char>()
            {
                { ".-"   ,'A'},
                { "-..." ,'B'},
                { "-.-." ,'C'},
                { "-.."  ,'D'},
                { "."    ,'E'},
                { "..-." ,'F'},
                { "--."  ,'G'},
                { "...." ,'H'},
                { ".."   ,'I'},
                { ".---" ,'J'},
                { "-.-"  ,'K'},
                { ".-.." ,'L'},
                { "--"   ,'M'},
                { "-."   ,'N'},
                { "---"  ,'O'},
                { ".--." ,'P'},
                { "--.-" ,'Q'},
                { ".-."  ,'R'},
                { "..."  ,'S'},
                { "-"    ,'T'},
                { "..-"  ,'U'},
                { "...-" ,'V'},
                { ".--"  ,'W'},
                { "-..-" ,'X'},
                { "-.--" ,'Y'},
                { "--.." ,'Z'}
            };

            List<string> morseCodedWords = Console.ReadLine()
                .Split("|")
                .ToList();

            List<string> message = new List<string>();

            foreach (var word in morseCodedWords)
            {
                StringBuilder sb = new StringBuilder();
                string[] letters = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var letter in letters)
                {
                    sb.Append(morseCodes[letter]);
                }

                message.Add(sb.ToString());
            }

            Console.WriteLine(string.Join(" ", message));
        }
    }
}