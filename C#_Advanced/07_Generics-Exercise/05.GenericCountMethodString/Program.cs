namespace _05.GenericCountMethodString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>();

            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }

            string comparisonElement = Console.ReadLine();

            Box<string> box = new Box<string>(comparisonElement);
            int count = box.CountGreaterThan(strings, comparisonElement);
            Console.WriteLine(count);
        }
    }
}