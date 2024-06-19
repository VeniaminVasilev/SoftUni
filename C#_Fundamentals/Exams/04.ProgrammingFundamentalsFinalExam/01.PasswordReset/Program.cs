namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Done")
                {
                    Console.WriteLine($"Your password is: {password}");
                    break;
                }

                string[] tokens = command.Split(" ");
                string action = tokens[0];

                if (action == "TakeOdd")
                {
                    string oddCharacters = string.Empty;
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        oddCharacters += password[i];
                    }
                    password = oddCharacters;
                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string substring = tokens[1];
                    string substitute = tokens[2];
                    
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine($"Nothing to replace!");
                    }
                }
            }
        }
    }
}