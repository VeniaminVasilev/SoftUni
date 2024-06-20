namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Generate")
                {
                    Console.WriteLine($"Your activation key is: {activationKey}");
                    break;
                }

                string[] tokens = command.Split(">>>");
                string action = tokens[0];

                if (action == "Contains")
                {
                    string substring = tokens[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string caseOfSubstring = tokens[1];
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);

                    if (caseOfSubstring == "Upper")
                    {
                        string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                        string upperSubstring = substring.ToUpper();
                        activationKey = activationKey.Remove(startIndex, substring.Length);
                        activationKey = activationKey.Insert(startIndex, upperSubstring);
                        Console.WriteLine(activationKey);
                    }
                    else if (caseOfSubstring == "Lower")
                    {
                        string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                        string lowerSubstring = substring.ToLower();
                        activationKey = activationKey.Remove(startIndex, substring.Length);
                        activationKey = activationKey.Insert(startIndex, lowerSubstring);
                        Console.WriteLine(activationKey);
                    }
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }
            }
        }
    }
}