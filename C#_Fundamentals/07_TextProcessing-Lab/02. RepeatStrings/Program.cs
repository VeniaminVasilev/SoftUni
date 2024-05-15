using System.Text;

namespace _02._RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ");

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string str in array)
            {
                int count = str.Length;

                for (int i = 0; i < count; i++)
                {
                    stringBuilder.Append(str);
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}