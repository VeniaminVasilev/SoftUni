namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            char[][] field = new char[fieldSize][];

            for (int i = 0; i < fieldSize; i++)
            {
                field[i] = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            }

            var startInformation = field
                .SelectMany((row, rowIndex) => row
                .Select((col, colIndex) => new { Char = col, Row = rowIndex, Col = colIndex }))
                .FirstOrDefault(x => x.Char == 's');

            int startRow = 0;
            int startCol = 0;

            if (startInformation != null)
            {
                startRow = startInformation.Row;
                startCol = startInformation.Col;
            }

            int currentRow = startRow;
            int currentCol = startCol;

            int countOfCollectedCoal = 0;
            int countOfAllCoalInField = field
                .SelectMany(row => row)
                .Count(c => c == 'c');

            bool allCoalFound = false;
            bool gameOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up" & CellExists(currentRow - 1, currentCol, field))
                {
                    currentRow -= 1;
                }
                else if (commands[i] == "down" & CellExists(currentRow + 1, currentCol, field))
                {
                    currentRow += 1;
                }
                else if (commands[i] == "left" & CellExists(currentRow, currentCol - 1, field))
                {
                    currentCol -= 1;
                }
                else if (commands[i] == "right" & CellExists(currentRow, currentCol + 1, field))
                {
                    currentCol += 1;
                }

                if (field[currentRow][currentCol] == 'c')
                {
                    field[currentRow][currentCol] = '*';
                    countOfCollectedCoal++;

                    if (countOfCollectedCoal == countOfAllCoalInField)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        allCoalFound = true;
                        break;
                    }
                }
                else if (field[currentRow][currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    gameOver = true;
                    break;
                }
            }

            if (allCoalFound == false && gameOver == false)
            {
                Console.WriteLine($"{countOfAllCoalInField - countOfCollectedCoal} coals left. ({currentRow}, {currentCol})");
            }
        }

        private static bool CellExists(int row, int col, char[][] field)
        {
            if (row >= 0 && row < field.Length && col >= 0 && col < field.Length)
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