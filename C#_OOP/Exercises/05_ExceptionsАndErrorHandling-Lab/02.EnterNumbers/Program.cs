namespace _02.EnterNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            int lastNumber = 1;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int currentNumber = ReadNumber(lastNumber, 100);
                    array[i] = currentNumber;
                    lastNumber = currentNumber;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            int number = 0;

            if (!int.TryParse(input, out number))
            {
                throw new ArgumentException("Invalid Number!");
            }
            else
            {
                number = int.Parse(input);
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}