namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine($"{carsPassed} cars passed the crossroads.");
                    break;
                }
                else if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }
}