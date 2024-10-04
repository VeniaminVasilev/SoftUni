namespace _02.EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int playerRow = 0;
            int playerCol = 0;
            int playerHealth = 100;
            bool exitFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            while (true)
            {
                int currentRow = playerRow;
                int currentCol = playerCol;

                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (currentRow == 0)
                    {
                        continue;
                    }
                    else
                    {
                        currentRow--;
                    }
                }
                else if (command == "down")
                {
                    if (currentRow == n - 1)
                    {
                        continue;
                    }
                    else
                    {
                        currentRow++;
                    }
                }
                else if (command == "left")
                {
                    if (currentCol == 0)
                    {
                        continue;
                    }
                    else
                    {
                        currentCol--;
                    }
                }
                else if (command == "right")
                {
                    if (currentCol == n - 1)
                    {
                        continue;
                    }
                    else
                    {
                        currentCol++;
                    }
                }

                if (matrix[currentRow][currentCol] == 'M')
                {
                    playerHealth -= 40;
                    matrix[currentRow][currentCol] = '-';
                }
                else if (matrix[currentRow][currentCol] == 'H')
                {
                    playerHealth += 15;

                    if (playerHealth > 100) { playerHealth = 100; }
                    matrix[currentRow][currentCol] = '-';
                }
                else if (matrix[currentRow][currentCol] == 'X')
                {
                    exitFound = true;
                }

                playerRow = currentRow;
                playerCol = currentCol;
                
                if (playerHealth <= 0) { break; }

                if (exitFound) { break; }
            }

            matrix[playerRow][playerCol] = 'P';

            if (playerHealth <= 0)
            {
                playerHealth = 0;
                Console.WriteLine("Player is dead. Maze over!");
            }
            else
            {
                Console.WriteLine("Player escaped the maze. Danger passed!");
            }

            Console.WriteLine($"Player's health: {playerHealth} units");

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}