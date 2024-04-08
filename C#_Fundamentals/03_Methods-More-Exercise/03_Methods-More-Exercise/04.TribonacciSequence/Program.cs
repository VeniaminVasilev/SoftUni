namespace _04.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(num);
        }

        static void PrintTribonacciSequence(int num)
        {
            int[] sequence = new int[num];
            sequence[0] = 1;

            for (int i = 1; i < num; i++)
            {
                if (i == 1)
                {
                    sequence[i] = 1;
                }
                else if (i == 2)
                {
                    sequence[i] = 2;
                }
                if (i >= 3)
                {
                    sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
                }
            }

            for (int i = 0; i < num; i++)
            {
                Console.Write($"{sequence[i]} ");
            }
        }
    }
}