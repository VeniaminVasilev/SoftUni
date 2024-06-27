namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine($"{people.Count} people remaining.");
                    break;
                }
                else if (input == "Paid")
                {
                    int count = people.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(input);
                }
            }
        }
    }
}