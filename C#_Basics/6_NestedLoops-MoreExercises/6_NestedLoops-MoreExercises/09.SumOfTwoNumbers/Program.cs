int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
int magicNumber = int.Parse(Console.ReadLine());

int combinations = 0;
bool isFound = false;

for (int i = start; i <= end; i++)
{
    for (int j = start; j <= end; j++)
    {
        combinations++;

        if (i + j == magicNumber)
        {
            Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNumber})");
            isFound = true;
            break;
        }
    }

    if (isFound) { break; }
}

if (isFound == false)
{
    Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
}