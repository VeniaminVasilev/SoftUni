namespace _02.CollectingStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int stars = 2;

            string[][] matrix = new string[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = new string[n];

                string[] currentRow = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            while (stars > 0 && stars < 10)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    for (int row = 0; row < n; row++)
                    {
                        bool actionMade = false;

                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row][col] == "P")
                            {
                                if (row == 0)
                                {
                                    if (matrix[0][0] == "*")
                                    {
                                        stars++;
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                    else
                                    {
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                }
                                else if (matrix[row - 1][col] == "#")
                                {
                                    stars--;
                                }
                                else if (matrix[row - 1][col] == "*")
                                {
                                    stars++;
                                    matrix[row - 1][col] = "P";
                                    matrix[row][col] = ".";
                                }
                                else if (matrix[row - 1][col] == ".")
                                {
                                    matrix[row - 1][col] = "P";
                                    matrix[row][col] = ".";
                                }
                                actionMade = true;
                                break;
                            }
                        }
                        if (actionMade) { break; }
                    }
                }
                else if (command == "down")
                {
                    bool actionMade = false;
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row][col] == "P")
                            {
                                if (row == n - 1)
                                {
                                    if (matrix[0][0] == "*")
                                    {
                                        stars++;
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                    else
                                    {
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                }
                                else if (matrix[row + 1][col] == "#")
                                {
                                    stars--;
                                }
                                else if (matrix[row + 1][col] == "*")
                                {
                                    stars++;
                                    matrix[row + 1][col] = "P";
                                    matrix[row][col] = ".";
                                }
                                else if (matrix[row + 1][col] == ".")
                                {
                                    matrix[row + 1][col] = "P";
                                    matrix[row][col] = ".";
                                }
                                actionMade = true;
                                break;
                            }
                        }
                        if (actionMade) { break; }
                    }
                }
                else if (command == "left")
                {
                    for (int row = 0; row < n; row++)
                    {
                        bool actionMade = false;
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row][col] == "P")
                            {
                                if (col == 0)
                                {
                                    if (matrix[0][0] == "*")
                                    {
                                        stars++;
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                    else
                                    {
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                }
                                else if (matrix[row][col - 1] == "#")
                                {
                                    stars--;
                                }
                                else if (matrix[row][col - 1] == "*")
                                {
                                    stars++;
                                    matrix[row][col - 1] = "P";
                                    matrix[row][col] = ".";
                                }
                                else if (matrix[row][col - 1] == ".")
                                {
                                    matrix[row][col - 1] = "P";
                                    matrix[row][col] = ".";
                                }
                                actionMade = true;
                                break;
                            }
                        }
                        if (actionMade) { break; }
                    }
                }
                else if (command == "right")
                {
                    for (int row = 0; row < n; row++)
                    {
                        bool actionMade = false;
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row][col] == "P")
                            {
                                if (col == n - 1)
                                {
                                    if (matrix[0][0] == "*")
                                    {
                                        stars++;
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                    else
                                    {
                                        matrix[row][col] = ".";
                                        matrix[0][0] = "P";
                                    }
                                }
                                else if (matrix[row][col + 1] == "#")
                                {
                                    stars--;
                                }
                                else if (matrix[row][col + 1] == "*")
                                {
                                    stars++;
                                    matrix[row][col + 1] = "P";
                                    matrix[row][col] = ".";
                                }
                                else if (matrix[row][col + 1] == ".")
                                {
                                    matrix[row][col + 1] = "P";
                                    matrix[row][col] = ".";
                                }
                                actionMade = true;
                                break;
                            }
                        }
                        if (actionMade) { break; }
                    }
                }

                if (stars >= 10 || stars <= 0)
                {
                    break;
                }
            }

            int[] playerFinalPosition = new int[2];
            for (int row = 0; row < n; row++)
            {
                bool playerFound = false;
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == "P")
                    {
                        playerFinalPosition[0] = row;
                        playerFinalPosition[1] = col;
                        playerFound = true;
                        break;
                    }
                }
                if (playerFound) { break; }
            }

            if (stars == 10)
            {
                Console.WriteLine("You won! You have collected 10 stars.");
            }
            else if (stars == 0)
            {
                Console.WriteLine("Game over! You are out of any stars.");
            }

            Console.WriteLine($"Your final position is [{playerFinalPosition[0]}, {playerFinalPosition[1]}]");

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}