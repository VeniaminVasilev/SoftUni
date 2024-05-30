namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int bomb = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '>' & bomb > 0)
                {
                    line = line.Remove(i, 1);
                    bomb--;
                    i--;
                }
                else if (line[i] == '>')
                {
                    bomb += int.Parse(line[i + 1].ToString());
                }
            }
            Console.WriteLine(line);
        }
    }
}