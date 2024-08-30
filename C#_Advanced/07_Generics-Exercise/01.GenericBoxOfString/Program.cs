namespace _01.GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentString = Console.ReadLine();
                Box<string> boxWithString = new Box<string>(currentString);
                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}