namespace _02.BombHasBeenPlanted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            char[][] field = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
            }

            int secondsLeft = 16;

            int counterTerroristRow = 0;
            int counterTerroristColumn = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (field[row][column] == 'C')
                    {
                        counterTerroristRow = row;
                        counterTerroristColumn = column;
                        break;
                    }
                }
            }

            bool bombDefused = false;
            bool counterTerroristKilled = false;

            while (true)
            {
                if (secondsLeft <= 0 || bombDefused || counterTerroristKilled)
                {
                    break;
                } 

                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (counterTerroristColumn > 0)
                    {
                        counterTerroristColumn--;
                        secondsLeft--;
                    }
                    else
                    {
                        secondsLeft--;
                    }
                }
                else if (command == "right")
                {
                    if (counterTerroristColumn < columns - 1)
                    {
                        counterTerroristColumn++;
                        secondsLeft--;
                    }
                    else
                    {
                        secondsLeft--;
                    }
                }
                else if (command == "up")
                {
                    if (counterTerroristRow > 0)
                    {
                        counterTerroristRow--;
                        secondsLeft--;
                    }
                    else
                    {
                        secondsLeft--;
                    }
                }
                else if (command == "down")
                {
                    if (counterTerroristRow < rows - 1)
                    {
                        counterTerroristRow++;
                        secondsLeft--;
                    }
                    else
                    {
                        secondsLeft--;
                    }
                }
                else if (command == "defuse")
                {
                    if (field[counterTerroristRow][counterTerroristColumn] == 'B')
                    {
                        if (secondsLeft >= 4)
                        {
                            secondsLeft -= 4;
                            Console.WriteLine($"Counter-terrorist wins!");
                            Console.WriteLine($"Bomb has been defused: {secondsLeft} second/s remaining.");

                            field[counterTerroristRow][counterTerroristColumn] = 'D';
                            bombDefused = true;
                            break;
                        }
                        else
                        {
                            counterTerroristKilled = true;
                            field[counterTerroristRow][counterTerroristColumn] = 'X';
                            Console.WriteLine($"Terrorists win!");
                            Console.WriteLine($"Bomb was not defused successfully!");
                            Console.WriteLine($"Time needed: {4 - secondsLeft} second/s.");
                            secondsLeft = 0;
                            break;
                        }
                    }
                    else
                    {
                        secondsLeft -= 2;
                    }
                }

                if (field[counterTerroristRow][counterTerroristColumn] == 'T')
                {
                    Console.WriteLine("Terrorists win!");
                    counterTerroristKilled = true;
                    field[counterTerroristRow][counterTerroristColumn] = '*';
                    break;
                }

                if (secondsLeft <= 0)
                {
                    counterTerroristKilled = true;
                    Console.WriteLine($"Terrorists win!");
                    Console.WriteLine($"Bomb was not defused successfully!");
                    Console.WriteLine($"Time needed: {secondsLeft} second/s.");

                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine($"{string.Join("", field[row])}");
            }
        }
    }
}