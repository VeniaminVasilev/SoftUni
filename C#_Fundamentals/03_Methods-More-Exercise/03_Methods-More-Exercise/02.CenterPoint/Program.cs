namespace _02.CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosestPointToTheCenter(x1, y1, x2, y2);
        }

        static void PrintClosestPointToTheCenter(double x1, double y1, double x2, double y2)
        {
            double point1 = (x1 * x1) + (y1 * y1);
            double point2 = (x2 * x2) + (y2 * y2);
            
            if (point1 <= point2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (point2 < point1)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}