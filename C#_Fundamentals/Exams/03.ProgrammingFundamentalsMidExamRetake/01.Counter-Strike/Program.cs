namespace _01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wonBattles = 0;
            int counter = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End of battle")
                {
                    Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
                    break;
                }

                int distance = int.Parse(command);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    break;
                }
                else
                {
                    energy -= distance;
                    wonBattles++;
                    counter++;
                }

                if (counter % 3 == 0)
                {
                    energy += wonBattles;
                }
            }
        }
    }
}