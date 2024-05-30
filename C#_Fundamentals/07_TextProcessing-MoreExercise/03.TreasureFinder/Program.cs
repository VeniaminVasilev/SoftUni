namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "find") { break; }

                int j = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    int current = (int)line[i];
                    current -= keys[j];
                    string currentCharacter = ((char)current).ToString();
                    line = line.Remove(i, 1);
                    line = line.Insert(i, currentCharacter);

                    j++;
                    if (j == keys.Length) { j = 0; }
                }
                int firstIndexOfType = line.IndexOf('&') + 1;
                int lastIndexOfType = line.LastIndexOf('&');
                int firstIndexOfCoordinates = line.IndexOf('<') + 1;
                int lastIndexOfCoordinates = line.IndexOf('>');

                string type = line.Substring(firstIndexOfType, lastIndexOfType - firstIndexOfType);
                string coordinates = line.Substring(firstIndexOfCoordinates, lastIndexOfCoordinates - firstIndexOfCoordinates);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}