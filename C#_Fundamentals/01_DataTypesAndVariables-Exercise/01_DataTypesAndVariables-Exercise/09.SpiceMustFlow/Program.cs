int startingYield = int.Parse(Console.ReadLine());

int currentYield = startingYield;
int days = 0;
int totalAmountSpiceExtracted = 0;

while (true)
{
    if (currentYield < 100 && totalAmountSpiceExtracted >= 26)
    {
        totalAmountSpiceExtracted -= 26;
        break;
    }
    else if (currentYield < 100)
    {
        break;
    }
    
    days++;
    totalAmountSpiceExtracted += currentYield - 26;
    currentYield -= 10;
}

Console.WriteLine(days);
Console.WriteLine(totalAmountSpiceExtracted);