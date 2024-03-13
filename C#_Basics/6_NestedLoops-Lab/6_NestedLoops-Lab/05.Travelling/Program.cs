double currentMoney = 0;

while (true)
{
    string destination = Console.ReadLine();

    if (destination == "End")
    {
        break;
    }

    double neededSum = double.Parse(Console.ReadLine());

    while (true)
    {
        double currentSum = double.Parse(Console.ReadLine());
        currentMoney += currentSum;

        if (currentMoney >= neededSum)
        {
            Console.WriteLine($"Going to {destination}!");
            break;
        }

    }
    currentMoney = 0;
}