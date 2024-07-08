namespace _3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    squareMatrix[row, col] = numbers[col];
                }
            }

            int sumNumbersPrimaryDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                sumNumbersPrimaryDiagonal += squareMatrix[row, row];
            }

            Console.WriteLine(sumNumbersPrimaryDiagonal);
        }
    }
}