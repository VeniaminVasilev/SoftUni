namespace _01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                int startIndexOfName = line.IndexOf('@') + 1;
                int endIndexOfName = line.IndexOf('|');
                string name = line.Substring(startIndexOfName, endIndexOfName - startIndexOfName);

                int startIndexOfAge = line.IndexOf('#') + 1;
                int endIndexOfAge = line.IndexOf('*');
                string age = line.Substring(startIndexOfAge, endIndexOfAge - startIndexOfAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}