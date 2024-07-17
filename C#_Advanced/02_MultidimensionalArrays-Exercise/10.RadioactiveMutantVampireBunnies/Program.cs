namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];
            bool playerWins = false;
            int finalRow = -1;
            int finalCol = -1;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];
                var positionOfP = matrix
                    .SelectMany((row, rowIndex) => row.Select((value, colIndex) => new { value, rowIndex, colIndex }))
                    .FirstOrDefault(x => x.value == 'P');
                int rowOfP = 0; ;
                int colOfP = 0;

                if (positionOfP != null)
                {
                    rowOfP = positionOfP.rowIndex;
                    colOfP = positionOfP.colIndex;
                }
                else
                {
                    break;
                }

                if (direction == 'R')
                {
                    if (CellExists(matrix, rowOfP, colOfP + 1, rows, cols) && matrix[rowOfP][colOfP + 1] == '.')
                    {
                        matrix[rowOfP][colOfP + 1] = 'P';
                        matrix[rowOfP][colOfP] = '.';
                        finalRow = rowOfP;
                        finalCol = colOfP + 1;
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                    }
                    else if (CellExists(matrix, rowOfP, colOfP + 1, rows, cols) && matrix[rowOfP][colOfP + 1] == 'B')
                    {
                        finalRow = rowOfP;
                        finalCol = colOfP + 1;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                    else
                    {
                        playerWins = true;
                        finalRow = rowOfP;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                }
                else if (direction == 'L')
                {
                    if (CellExists(matrix, rowOfP, colOfP - 1, rows, cols) && matrix[rowOfP][colOfP - 1] == '.')
                    {
                        matrix[rowOfP][colOfP - 1] = 'P';
                        matrix[rowOfP][colOfP] = '.';
                        finalRow = rowOfP;
                        finalCol = colOfP - 1;
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                    }
                    else if (CellExists(matrix, rowOfP, colOfP - 1, rows, cols) && matrix[rowOfP][colOfP - 1] == 'B')
                    {
                        finalRow = rowOfP;
                        finalCol = colOfP - 1;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                    else
                    {
                        playerWins = true;
                        finalRow = rowOfP;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                }
                else if (direction == 'U')
                {
                    if (CellExists(matrix, rowOfP - 1, colOfP, rows, cols) && matrix[rowOfP - 1][colOfP] == '.')
                    {
                        matrix[rowOfP - 1][colOfP] = 'P';
                        matrix[rowOfP][colOfP] = '.';
                        finalRow = rowOfP - 1;
                        finalCol = colOfP;
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                    }
                    else if (CellExists(matrix, rowOfP - 1, colOfP, rows, cols) && matrix[rowOfP - 1][colOfP] == 'B')
                    {
                        finalRow = rowOfP - 1;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                    else
                    {
                        playerWins = true;
                        finalRow = rowOfP;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                }
                else if (direction == 'D')
                {
                    if (CellExists(matrix, rowOfP + 1, colOfP, rows, cols) && matrix[rowOfP + 1][colOfP] == '.')
                    {
                        matrix[rowOfP + 1][colOfP] = 'P';
                        matrix[rowOfP][colOfP] = '.';
                        finalRow = rowOfP + 1;
                        finalCol = colOfP;
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                    }
                    else if (CellExists(matrix, rowOfP + 1, colOfP, rows, cols) && matrix[rowOfP + 1][colOfP] == 'B')
                    {
                        finalRow = rowOfP + 1;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                    else
                    {
                        playerWins = true;
                        finalRow = rowOfP;
                        finalCol = colOfP;
                        matrix[rowOfP][colOfP] = '.';
                        matrix = SpreadOfBunnies(matrix, rows, cols);
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join("", r))));
            if (playerWins)
            {
                Console.WriteLine($"won: {finalRow} {finalCol}");
            }
            else
            {
                Console.WriteLine($"dead: {finalRow} {finalCol}");
            }
        }

        private static char[][] SpreadOfBunnies(char[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (CellExists(matrix, row, col - 1, rows, cols))
                        {
                            if (matrix[row][col - 1] != 'B')
                            {
                                matrix[row][col - 1] = 'b';
                            }
                        }
                        
                        if (CellExists(matrix, row - 1, col, rows, cols))
                        {
                            if (matrix[row - 1][col] != 'B')
                            {
                                matrix[row - 1][col] = 'b';
                            }
                        }
                        
                        if (CellExists(matrix, row, col + 1, rows, cols))
                        {
                            if (matrix[row][col + 1] != 'B')
                            {
                                matrix[row][col + 1] = 'b';
                            }
                        }
                        
                        if (CellExists(matrix, row + 1, col, rows, cols))
                        {
                            if (matrix[row + 1][col] != 'B')
                            {
                                matrix[row + 1][col] = 'b';
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        matrix[row][col] = 'B';
                    }
                }
            }

            return matrix;
        }

        private static bool CellExists(char[][] matrix, int currentRow, int currentCol, int rows, int cols)
        {
            if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols)
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