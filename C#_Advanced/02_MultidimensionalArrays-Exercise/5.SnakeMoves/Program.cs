namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            string snake = Console.ReadLine();
            List<char> snakeCharacters = new List<char>(snake.ToCharArray());
            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];

                if (row % 2 == 1)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        char currentCharacter = snakeCharacters[0];
                        matrix[row][col] = currentCharacter;
                        snakeCharacters.RemoveAt(0);
                        snakeCharacters.Add(currentCharacter);
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char currentCharacter = snakeCharacters[0];
                        matrix[row][col] = currentCharacter;
                        snakeCharacters.RemoveAt(0);
                        snakeCharacters.Add(currentCharacter);
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join("", r))));
        }
    }
}