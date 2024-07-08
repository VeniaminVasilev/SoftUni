namespace _6.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                int[] currentNumbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = currentNumbers;
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    for (int i = 0; i < matrixRows; i++)
                    {
                        Console.WriteLine(string.Join(" ", jaggedArray[i]));
                    }
                    break;
                }

                string[] tokens = command.Split(" ").ToArray();
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= matrixRows || column >= jaggedArray[row].Length || column < 0)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][column] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }
        }
    }
}