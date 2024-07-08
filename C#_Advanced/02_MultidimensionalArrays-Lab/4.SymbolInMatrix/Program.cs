namespace _4.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] squareMatrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    squareMatrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool symbolFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (squareMatrix[row, col] == symbol)
                    {
                        symbolFound = true;
                        int rowOfSymbol = row;
                        int colOfSymbol = col;
                        Console.WriteLine($"({rowOfSymbol}, {colOfSymbol})");
                        break;
                    }
                }
                if (symbolFound) { break; }
            }

            if (!symbolFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}