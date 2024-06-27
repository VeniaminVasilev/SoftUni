namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> children = Console.ReadLine()
                .Split(" ")
                .ToList();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queueChildren = new Queue<string>();

            for (int i = 0; i < children.Count; i++)
            {
                queueChildren.Enqueue(children[i]);
            }

            while (queueChildren.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string child = queueChildren.Dequeue();
                    queueChildren.Enqueue(child);
                }
                Console.WriteLine($"Removed {queueChildren.Dequeue()}");
            }

            Console.WriteLine($"Last is {queueChildren.Dequeue()}");
        }
    }
}