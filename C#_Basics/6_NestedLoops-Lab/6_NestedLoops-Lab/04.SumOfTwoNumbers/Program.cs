int startingNumber = int.Parse(Console.ReadLine());
int endingNumber = int.Parse(Console.ReadLine());
int magicNumber = int.Parse(Console.ReadLine());

int combinations = 0;
bool isFound = false;

for (int i = startingNumber; i <= endingNumber; i++)
{
    for (int j = startingNumber; j <= endingNumber; j++)
    {
        combinations++;
        if (i + j == magicNumber)
        {
            Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNumber})");
            isFound = true;
            break;
        }
    }

    if (isFound == true)
    {
        break;
    }
}

if (isFound == false)
{
    Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
}