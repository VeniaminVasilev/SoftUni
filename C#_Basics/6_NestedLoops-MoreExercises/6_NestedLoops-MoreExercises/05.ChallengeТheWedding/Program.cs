int numberOfMen = int.Parse(Console.ReadLine());
int numberOfWomen = int.Parse(Console.ReadLine());
int tables = int.Parse(Console.ReadLine());

int occupiedTables = 0;

for (int man = 1; man <= numberOfMen; man++)
{
    for (int woman = 1; woman <= numberOfWomen; woman++)
    {
        if (tables <= occupiedTables)
        {
            break;
        }

        Console.Write($"({man} <-> {woman}) ");
        occupiedTables++;
    }

    if (tables <= occupiedTables)
    {
        break;
    }
}