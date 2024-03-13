string mostPowerfulWord = string.Empty;
double highestPower = 0;

while (true)
{
    string command = Console.ReadLine();

    if (command == "End of words")
    {
        break;
    }

    int commandLength = command.Length;
    double sum = 0;

    for (int i = 0; i < commandLength; i++)
    {
        char currentDigit = command[i];
        int currentNumber = (int)currentDigit;

        sum += currentNumber;
    }

    char firstDigit = command[0];
    int firstNumber = (int)firstDigit;

    if (firstNumber == 65 || firstNumber == 69 || firstNumber == 73 || firstNumber == 79 || firstNumber == 85 || firstNumber == 89)
    {
        sum *= commandLength;
    }
    else if (firstNumber == 97 || firstNumber == 101 || firstNumber == 105 || firstNumber == 111 || firstNumber == 117 || firstNumber == 121)
    {
        sum *= commandLength;
    }
    else
    {
        sum = Math.Floor(sum / commandLength);
    }

    if (sum > highestPower)
    {
        highestPower = sum;
        mostPowerfulWord = command;
    }
}

Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {highestPower}");