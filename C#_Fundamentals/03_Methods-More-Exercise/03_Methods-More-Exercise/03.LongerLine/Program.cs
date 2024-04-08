namespace _03.LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double line1 = GetLengthOfLine(x1, y1, x2, y2);
            double line2 = GetLengthOfLine(x3, y3, x4, y4);

            if (line1 >= line2)
            {
                PrintClosestPointToTheCenter(x1, y1, x2, y2);
            }
            else
            {
                PrintClosestPointToTheCenter(x3, y3, x4, y4);
            }
        }

        static double GetLengthOfLine(double x1, double y1, double x2, double y2)
        {
            double length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return length;
        }

        static void PrintClosestPointToTheCenter(double x1, double y1, double x2, double y2)
        {
            double point1 = (x1 * x1) + (y1 * y1);
            double point2 = (x2 * x2) + (y2 * y2);

            if (point1 <= point2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else if (point2 < point1)
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}