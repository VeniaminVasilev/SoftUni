namespace _01.SquareRoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                if (number < 0)
                {
                    Console.WriteLine("Invalid number.");
                }
                else
                {
                    double squareRoot = Math.Sqrt(number);
                    Console.WriteLine(squareRoot);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}