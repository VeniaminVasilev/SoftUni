namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            List<int> result = new List<int>();

            for (int i = 0; i < Math.Max(list1.Count, list2.Count); i++)
            {
                if (i < list1.Count)
                {
                    result.Add(list1[i]);
                }

                if (i < list2.Count)
                {
                    result.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}