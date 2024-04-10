namespace _02.GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int size = list.Count;

            for (int i = 0; i < size / 2; i++)
            {
                list[i] += list[size - 1 - i];
                list.RemoveAt(size - 1 - i);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}