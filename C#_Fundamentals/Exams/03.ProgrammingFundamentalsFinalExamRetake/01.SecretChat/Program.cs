namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Reveal")
                {
                    Console.WriteLine($"You have a new text message: {message}");
                    break;
                }

                string[] tokens = command.Split(":|:");
                string action = tokens[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);

                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substring = tokens[1];

                    if (message.Contains(substring))
                    {
                        int indexOfSubstring = message.IndexOf(substring);
                        message = message.Remove(indexOfSubstring, substring.Length);
                        string reversedSubstring = new string(substring.Reverse().ToArray());
                        message = message + reversedSubstring;

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }
            }
        }
    }
}