namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfOperations = int.Parse(Console.ReadLine());
            Stack<string> versionsOfText = new Stack<string>();
            string currentVersionOfText = string.Empty;

            for (int i = 0; i < countOfOperations; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ").ToArray();
                string command = tokens[0];

                if (command == "1")
                {
                    string additionalText = tokens[1];
                    currentVersionOfText += additionalText;

                    versionsOfText.Push(currentVersionOfText);
                }
                else if (command == "2")
                {
                    int count = int.Parse(tokens[1]);
                    currentVersionOfText = currentVersionOfText.Remove(currentVersionOfText.Length - count);

                    versionsOfText.Push(currentVersionOfText);
                }
                else if (command == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(currentVersionOfText[index - 1]);
                }
                else if (command == "4")
                {
                    versionsOfText.Pop();

                    if (versionsOfText.Count > 0)
                    {
                        currentVersionOfText = versionsOfText.Peek();
                    }
                    else
                    {
                        currentVersionOfText = string.Empty;
                    }
                }
            }
        }
    }
}