namespace _02.ClearSkies
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

            int jetRow = 0;
            int jetCol = 0;
            int countEnemies = 0;
            int armor = 300;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == 'J')
                    {
                        jetRow = row;
                        jetCol = col;
                        matrix[row][col] = '-';
                    }
                    else if (matrix[row][col] == 'E')
                    {
                        countEnemies++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    jetRow--;
                }
                else if (command == "down")
                {
                    jetRow++;
                }
                else if (command == "left")
                {
                    jetCol--;
                }
                else if (command == "right")
                {
                    jetCol++;
                }

                if (matrix[jetRow][jetCol] == 'E')
                {
                    matrix[jetRow][jetCol] = '-';
                    countEnemies--;

                    if (countEnemies == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                    else
                    {
                        armor -= 100;

                        if (armor <= 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
                            break;
                        }
                    }
                }
                else if (matrix[jetRow][jetCol] == 'R')
                {
                    armor = 300;
                    matrix[jetRow][jetCol] = '-';
                }
            }

            matrix[jetRow][jetCol] = 'J';

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}