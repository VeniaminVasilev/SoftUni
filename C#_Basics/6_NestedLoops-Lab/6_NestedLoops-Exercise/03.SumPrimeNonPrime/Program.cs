int sumPrimeNumbers = 0;
int sumNonPrimeNumbers = 0;

while (true)
{
    string command = Console.ReadLine();

    if (command == "stop")
    {
        Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
        Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");
        break;
    }

    int number = int.Parse(command);

    if (number < 0)
    {
        Console.WriteLine($"Number is negative.");
        continue;
    }
    
    if (number < 2)
    {
        continue;
    }

    bool isPrime = true;

    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
            sumNonPrimeNumbers += number;
            break;
        }
    }

    if (isPrime)
    {
        sumPrimeNumbers += number;
    }
}