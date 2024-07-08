namespace _1.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int countRows = matrix.GetLength(0);
            int countCols = matrix.GetLength(1);
            int sumMatrixElements = 0;

            foreach (int element in matrix)
            {
                sumMatrixElements += element;
            }

            Console.WriteLine(countRows);
            Console.WriteLine(countCols);
            Console.WriteLine(sumMatrixElements);
        }
    }
}