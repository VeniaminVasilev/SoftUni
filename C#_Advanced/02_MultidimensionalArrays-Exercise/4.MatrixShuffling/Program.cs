namespace _4.MatrixShuffling
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
            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") { break; }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool swap = false;

                if (tokens.Length == 5)
                {
                    string action = tokens[0];
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (action == "swap" && row1 >= 0 && row1 < rows && col1 >= 0 && col1 < cols && row2 >= 0 && row2 < rows && col2 >= 0 && col2 < cols)
                    {
                        string element1 = matrix[row1][col1];
                        string element2 = matrix[row2][col2];
                        matrix[row1][col1] = element2;
                        matrix[row2][col2] = element1;

                        swap = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                if (swap)
                {
                    Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join(" ", r))));
                }
            }
        }
    }
}