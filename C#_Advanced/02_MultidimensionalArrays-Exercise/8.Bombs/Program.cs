namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string[] bombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBombCoordinates = bombs[i].Split(',').Select(int.Parse).ToArray();
                int rowOfBomb = currentBombCoordinates[0];
                int colOfBomb = currentBombCoordinates[1];

                matrix = Explosion(rowOfBomb, colOfBomb, matrix);
            }

            List<int> positiveNumbers = matrix.SelectMany(row => row).Where(num => num > 0).ToList();
            int count = positiveNumbers.Count();
            int sum = positiveNumbers.Sum();
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join(" ", r))));
        }

        private static int[][] Explosion(int rowOfBomb, int colOfBomb, int[][] matrix)
        {
            int valueOfBomb = matrix[rowOfBomb][colOfBomb];

            if (valueOfBomb <= 0) { return matrix; }

            matrix[rowOfBomb][colOfBomb] = 0;
            
            if (CellExists(rowOfBomb + 1, colOfBomb, matrix)) // 1, 0
            {
                if (matrix[rowOfBomb + 1][colOfBomb] > 0)
                {
                    matrix[rowOfBomb + 1][colOfBomb] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb - 1, colOfBomb, matrix)) // -1, 0
            {
                if (matrix[rowOfBomb - 1][colOfBomb] > 0)
                {
                    matrix[rowOfBomb - 1][colOfBomb] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb, colOfBomb - 1, matrix)) // 0, -1
            {
                if (matrix[rowOfBomb][colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb][colOfBomb - 1] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb, colOfBomb + 1, matrix)) // 0, +1
            {
                if (matrix[rowOfBomb][colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb][colOfBomb + 1] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb - 1, colOfBomb - 1, matrix)) // -1, -1
            {
                if (matrix[rowOfBomb - 1][colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb - 1][colOfBomb - 1] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb - 1, colOfBomb + 1, matrix)) // -1, +1
            {
                if (matrix[rowOfBomb - 1][colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb - 1][colOfBomb + 1] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb + 1, colOfBomb - 1, matrix)) // +1, -1
            {
                if (matrix[rowOfBomb + 1][colOfBomb - 1] > 0)
                {
                    matrix[rowOfBomb + 1][colOfBomb - 1] -= valueOfBomb;
                }
            }

            if (CellExists(rowOfBomb + 1, colOfBomb + 1, matrix)) // +1, +1
            {
                if (matrix[rowOfBomb + 1][colOfBomb + 1] > 0)
                {
                    matrix[rowOfBomb + 1][colOfBomb + 1] -= valueOfBomb;
                }
            }

            return matrix;
        }

        private static bool CellExists(int row, int col, int[][] matrix)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}