namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> resources = new Dictionary<string, decimal>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop") { break; }

                decimal quantity = decimal.Parse(Console.ReadLine());

                if (!resources.ContainsKey(command))
                {
                    resources[command] = 0;
                }
                resources[command] += quantity;
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}