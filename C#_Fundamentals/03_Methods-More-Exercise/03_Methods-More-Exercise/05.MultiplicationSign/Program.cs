namespace _05.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            string multiplicationSign = GetMultiplicationSign(number1, number2, number3);
            Console.WriteLine(multiplicationSign);
        }

        static string GetMultiplicationSign(int number1, int number2, int number3)
        {
            // The idea of the exercise is to solve it without multiplying the 3 numbers
            string multiplicationSign = string.Empty;

            if (number1 > 0 && number2 > 0 && number3 > 0) { multiplicationSign = "positive"; }
            else if (number1 > 0 && number2 > 0 && number3 < 0) { multiplicationSign = "negative"; }
            else if (number1 > 0 && number2 < 0 && number3 > 0) { multiplicationSign = "negative"; }
            else if (number1 < 0 && number2 > 0 && number3 > 0) { multiplicationSign = "negative"; }
            else if (number1 > 0 && number2 < 0 && number3 < 0) { multiplicationSign = "positive"; }
            else if (number1 < 0 && number2 < 0 && number3 > 0) { multiplicationSign = "positive"; }
            else if (number1 < 0 && number2 < 0 && number3 < 0) { multiplicationSign = "negative"; }
            else if (number1 < 0 && number2 > 0 && number3 < 0) { multiplicationSign = "positive"; }
            else if (number1 == 0 || number2 == 0 || number3 == 0) { multiplicationSign = "zero"; }

            return multiplicationSign;
        }
    }
}