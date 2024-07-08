namespace _2.SumMatrixColumns
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
                int[] numbersForRow = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersForRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sumCurrentColumn = 0;

                for (int row = 0; row < rows; row++)
                {
                    sumCurrentColumn += matrix[row, col];
                }

                Console.WriteLine(sumCurrentColumn);
            }
        }
    }
}