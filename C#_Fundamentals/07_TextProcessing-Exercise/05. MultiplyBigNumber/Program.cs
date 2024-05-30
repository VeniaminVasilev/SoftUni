namespace _05._MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The idea of the exercise is to avoid using BigInteger. String should be used.
            char[] numberCharArray = Console.ReadLine()
                .TrimStart('0')
                .ToCharArray()
                .Reverse()
                .ToArray();

            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int inMind = 0;

            List<int> multiplicationList = new List<int>();

            foreach (char digit in numberCharArray)
            {
                int result = int.Parse(digit.ToString()) * multiplier + inMind;

                inMind = result / 10;
                result = result % 10;

                multiplicationList.Add(result);
            }

            if (inMind > 0)
            {
                multiplicationList.Add(inMind);
            }

            multiplicationList.Reverse();

            Console.WriteLine(string.Join(string.Empty, multiplicationList));
        }
    }
}