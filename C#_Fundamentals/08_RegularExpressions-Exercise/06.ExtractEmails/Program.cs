using System.Text.RegularExpressions;

namespace _07.ExtractEmails
{
    class Program
    {
        static void Main()
        {
            Regex emailRegex = new Regex(@"(\s[a-z]+[\w.-]+\w)@([a-z]+[-a-z]*?([.][a-z]+)+)\b");

            string input = Console.ReadLine();

            MatchCollection emails = emailRegex.Matches(input);

            foreach (Match email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}