using System.Text;
using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string pattern = @"@([A-Za-z]+)[^@\-!>:]*!(G)!";
            List<string> goodBehaviorChildren = new List<string>();

            while (true)
            {
                string encryptedMessage = Console.ReadLine();
                if (encryptedMessage == "end") { break; }

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    int currentCharacterInt = (char)encryptedMessage[i];
                    currentCharacterInt -= key;
                    char decryptedCharacter = (char)currentCharacterInt;
                    sb.Append(decryptedCharacter);
                }

                string decryptedMessage = sb.ToString();
                
                Match match = Regex.Match(decryptedMessage, pattern);
                if (match.Success)
                {
                    goodBehaviorChildren.Add(match.Groups[1].Value);
                }
            }

            foreach (string child in goodBehaviorChildren)
            {
                Console.WriteLine(child);
            }
        }
    }
}