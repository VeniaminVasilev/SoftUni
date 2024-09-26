namespace _02.Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int beeRow = 0, beeCol = 0;
            int energy = 15;
            int nectarCollected = 0;
            bool energyRestored = false;

            // Initialize the field and find the bee's initial position
            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = inputRow[col];
                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                // Calculate the next position based on the command
                int newRow = beeRow;
                int newCol = beeCol;

                switch (command)
                {
                    case "up": newRow--; break;
                    case "down": newRow++; break;
                    case "left": newCol--; break;
                    case "right": newCol++; break;
                }

                // Wrap around if the bee goes out of bounds
                if (newRow < 0) newRow = n - 1;
                if (newRow >= n) newRow = 0;
                if (newCol < 0) newCol = n - 1;
                if (newCol >= n) newCol = 0;

                // Update bee's position
                field[beeRow, beeCol] = '-';
                beeRow = newRow;
                beeCol = newCol;

                // Decrease energy by 1
                energy--;

                // Check the new position of the bee
                char currentCell = field[beeRow, beeCol];

                if (char.IsDigit(currentCell))
                {
                    nectarCollected += currentCell - '0';
                    field[beeRow, beeCol] = '-';
                }
                else if (currentCell == 'H')
                {
                    // Hive reached
                    field[beeRow, beeCol] = 'B';
                    if (nectarCollected >= 30)
                    {
                        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
                    }
                    else
                    {
                        Console.WriteLine("Beesy did not manage to collect enough nectar.");
                    }
                    PrintField(field);
                    return;
                }

                // Check if energy runs out
                if (energy <= 0)
                {
                    if (!energyRestored && nectarCollected >= 30)
                    {
                        // Restore energy once
                        energyRestored = true;
                        energy += nectarCollected - 30;
                        nectarCollected = 30;
                    }
                    else
                    {
                        field[beeRow, beeCol] = 'B';
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        PrintField(field);
                        return;
                    }
                }

                // Mark bee's current position
                field[beeRow, beeCol] = 'B';
            }
        }

        // Helper function to print the field
        static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}