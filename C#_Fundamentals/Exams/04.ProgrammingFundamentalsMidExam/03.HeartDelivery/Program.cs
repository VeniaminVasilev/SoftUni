namespace _03.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();

            int position = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Love!")
                {
                    Console.WriteLine($"Cupid's last position was {position}.");

                    bool allNumbersAreLessOrEqualZero = neighbourhood.All(x => x <= 0);

                    if (allNumbersAreLessOrEqualZero)
                    {
                        Console.WriteLine("Mission was successful.");
                    }
                    else
                    {
                        int countOfAllFailedHouses = neighbourhood.Count(x => x > 0);
                        Console.WriteLine($"Cupid has failed {countOfAllFailedHouses} places.");
                    }
                    break;
                }

                string[] tokens = command.Split(" ");
                int length = int.Parse(tokens[1]);

                int positionAfterJump = position + length;

                if (positionAfterJump >= neighbourhood.Count)
                {
                    positionAfterJump = 0;
                }

                if (neighbourhood[positionAfterJump] == 0)
                {
                    Console.WriteLine($"Place {positionAfterJump} already had Valentine's day.");
                } else
                {
                    neighbourhood[positionAfterJump] -= 2;

                    if (neighbourhood[positionAfterJump] == 0)
                    {
                        Console.WriteLine($"Place {positionAfterJump} has Valentine's day.");
                    }
                }

                position = positionAfterJump;
            }
        }
    }
}