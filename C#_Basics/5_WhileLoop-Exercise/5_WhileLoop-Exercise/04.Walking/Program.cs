int stepsSum = 0;

while (true)
{
    string command = Console.ReadLine();
    
    if (command == "Going home")
    {
        int goingHomeSteps = int.Parse(Console.ReadLine());
        stepsSum += goingHomeSteps;

        if (stepsSum < 10000)
        {
            Console.WriteLine($"{10000 - stepsSum} more steps to reach goal.");
        } else
        {
            Console.WriteLine($"Goal reached! Good job!");
            Console.WriteLine($"{stepsSum - 10000} steps over the goal!");
        }

        break;
    }

    int steps = int.Parse(command);
    stepsSum += steps;

    if (stepsSum >= 10000)
    {
        Console.WriteLine($"Goal reached! Good job!");
        Console.WriteLine($"{stepsSum - 10000} steps over the goal!");
        break;
    }
}