namespace _02.TheGambler
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

            int gamblerRow = 0;
            int gamblerCol = 0;
            int money = 100;
            bool gameLost = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 'G')
                    {
                        gamblerRow = row;
                        gamblerCol = col;
                        matrix[row][col] = '-';
                    }
                }
            }
            
            while (true)
            {
                int row = gamblerRow;
                int col = gamblerCol;

                string command = Console.ReadLine();

                if (command == "end")
                {
                    Console.WriteLine($"End of the game. Total amount: {money}$");
                    break;
                }

                if (command == "up")
                {
                    row--;
                }
                else if (command == "down")
                {
                    row++;
                }
                else if (command == "left")
                {
                    col--;
                }
                else if (command == "right")
                {
                    col++;
                }

                if (row < 0 || row >= n || col < 0 || col >= n)
                {
                    gameLost = true;
                    Console.WriteLine($"Game over! You lost everything!");
                    break;
                }

                if (matrix[row][col] == '-')
                {
                    gamblerRow = row;
                    gamblerCol = col;
                }
                else if (matrix[row][col] == 'W')
                {
                    money += 100;
                    matrix[row][col] = '-';
                    gamblerRow = row;
                    gamblerCol = col;
                }
                else if (matrix[row][col] == 'P')
                {
                    money -= 200;
                    matrix[row][col] = '-';
                    gamblerRow = row;
                    gamblerCol = col;
                }
                else if (matrix[row][col] == 'J')
                {
                    money += 100000;
                    matrix[row][col] = '-';
                    gamblerRow = row;
                    gamblerCol = col;
                    Console.WriteLine($"You win the Jackpot!\nEnd of the game. Total amount: {money}$");
                    break;
                }

                if (money <= 0)
                {
                    gameLost = true;
                    Console.WriteLine($"Game over! You lost everything!");
                    break;
                }
            }

            matrix[gamblerRow][gamblerCol] = 'G';

            if (gameLost == false)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.WriteLine(string.Join("", matrix[row]));
                }
            }
        }
    }
}