namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string line = Console.ReadLine();

            while (true)
            {
                int firstIndex = line.IndexOf(key);
                if (firstIndex < 0) { break; }
                line = line.Remove(firstIndex, key.Length);
            }
            Console.WriteLine(line);
        }
    }
}