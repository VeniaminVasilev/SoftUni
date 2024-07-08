namespace _5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentNumbers = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentNumbers[col];
                }
            }

            int maximumSum = int.MinValue;
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maximumSum)
                    {
                        maximumSum = currentSum;
                        number1 = matrix[row, col];
                        number2 = matrix[row, col + 1];
                        number3 = matrix[row + 1, col];
                        number4 = matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine($"{number1} {number2}");
            Console.WriteLine($"{number3} {number4}");
            Console.WriteLine(maximumSum);
        }
    }
}