namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentInt = int.Parse(Console.ReadLine());
                Box<int> boxWithInteger = new Box<int>(currentInt);
                Console.WriteLine(boxWithInteger.ToString());
            }
        }
    }
}