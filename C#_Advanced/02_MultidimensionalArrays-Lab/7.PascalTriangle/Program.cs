using System.Numerics;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            BigInteger[][] pascalTriangle = new BigInteger[size][];
            pascalTriangle[0] = new BigInteger[1];
            pascalTriangle[0][0] = 1;

            for (int i = 1; i < size; i++)
            {
                pascalTriangle[i] = new BigInteger[i + 1];
                pascalTriangle[i][0] = 1;

                for (int j = 1; j < i; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }

                pascalTriangle[i][i] = 1;
             }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[i]));
            }
        }
    }
}