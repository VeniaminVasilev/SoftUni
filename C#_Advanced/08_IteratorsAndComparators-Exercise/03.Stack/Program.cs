namespace _03.Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<string> newStack = new CustomStack<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    newStack.PrintAll();
                    newStack.PrintAll();
                    break;
                }

                if (command.StartsWith("Push"))
                {
                    string valuesPart = command.Substring(4);

                    List<string> values = valuesPart
                        .Trim()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    newStack.Push(values);
                }
                else if (command == "Pop")
                {
                    newStack.Pop();
                }
            }
        }
    }
}