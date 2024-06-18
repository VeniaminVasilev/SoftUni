using System.Text;

namespace _01.Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Registration") { break; }

                string[] tokens = input.Split(" ");
                string command = tokens[0];

                if (command == "Letters")
                {
                    if (tokens[1] == "Lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (tokens[1] == "Upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex < endIndex && startIndex >= 0 && startIndex < username.Length && endIndex >= 0 && endIndex < username.Length)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        string reversedSubstring = new string(substring.Reverse().ToArray());
                        Console.WriteLine(reversedSubstring);
                    }
                }
                else if (command == "Substring")
                {
                    string substring = tokens[1];

                    if (username.Contains(substring))
                    {
                        username = username.Remove(username.IndexOf(substring), substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The username {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    char character = char.Parse(tokens[1]);
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < username.Length; i++)
                    {
                        if (character != username[i])
                        {
                            sb.Append(username[i]);
                        }
                        else
                        {
                            sb.Append("-");
                        }
                    }
                    username = sb.ToString();
                    Console.WriteLine(username);
                }
                else if (command == "IsValid")
                {
                    char character = char.Parse(tokens[1]);

                    if (username.Contains(character))
                    {
                        Console.WriteLine("Valid username.");
                    }
                    else
                    {
                        Console.WriteLine($"{character} must be contained in your username.");
                    }
                }
            }
        }
    }
}