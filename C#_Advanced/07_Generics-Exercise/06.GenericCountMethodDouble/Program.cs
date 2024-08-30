namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> doubles = new List<double>();

            for (int i = 0; i < n; i++)
            {
                doubles.Add(double.Parse(Console.ReadLine()));
            }

            double comparisonElement = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(comparisonElement);
            int count = box.CountGreaterThan(doubles, comparisonElement);
            Console.WriteLine(count);
        }
    }
}