namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[][] matrix = new int[rows][];
            int maximumSum = int.MinValue;
            int[] startPositionOfMaximumSum = new int[2];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (sum > maximumSum)
                    {
                        maximumSum = sum;
                        startPositionOfMaximumSum[0] = row;
                        startPositionOfMaximumSum[1] = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maximumSum}");
            for (int row = startPositionOfMaximumSum[0]; row <= startPositionOfMaximumSum[0] + 2; row++)
            {
                int col = startPositionOfMaximumSum[1];
                Console.WriteLine($"{matrix[row][col]} {matrix[row][col + 1]} {matrix[row][col + 2]}");
            }
        }
    }
}