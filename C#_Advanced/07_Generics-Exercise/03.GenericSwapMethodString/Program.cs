namespace _03.GenericSwapMethodString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Collection<string> strings = new Collection<string>(new List<string>());

            for (int i = 0; i < n; i++)
            {
                string currentString = Console.ReadLine();
                strings.Elements.Add(currentString);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            strings.SwapElementsAndPrint(indexes[0], indexes[1]);
        }
    }
}