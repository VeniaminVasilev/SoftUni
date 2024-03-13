double neededMoney = double.Parse(Console.ReadLine());
double ownedMoney = double.Parse(Console.ReadLine());

int counterDays = 0;
int spendDays = 0;

while (true)
{
    string action = Console.ReadLine();
    double money = double.Parse(Console.ReadLine());

    if (action == "spend")
    {
        ownedMoney -= money;

        if (ownedMoney < 0)
        {
            ownedMoney = 0;
        }

        spendDays++;
        counterDays++;
    }

    if (action == "save")
    {
        ownedMoney += money;
        counterDays++;
        spendDays = 0;
    }

    if (ownedMoney >= neededMoney)
    {
        Console.WriteLine($"You saved the money for {counterDays} days.");
        break;
    }

    if (spendDays == 5)
    {
        Console.WriteLine($"You can't save the money.");
        Console.WriteLine(counterDays);
        break;
    }
}