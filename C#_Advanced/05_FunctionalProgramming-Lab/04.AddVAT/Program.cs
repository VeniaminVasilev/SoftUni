namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = (double price) => price * 1.20;

            double[] prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .ToArray();

            string[] pricesWithVAT = prices.Select(price => addVAT(price).ToString("F2")).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, pricesWithVAT));
        }
    }
}