int groups = int.Parse(Console.ReadLine());

int peopleMusala = 0;
int peopleMonblan = 0;
int peopleKilimandjaro = 0;
int peopleK2 = 0;
int peopleEverest = 0;
int allPeople = 0;

for (int i = 0; i < groups; i++)
{
    int peopleInGroup = int.Parse(Console.ReadLine());
    allPeople += peopleInGroup;

    if (peopleInGroup <= 5)
    {
        peopleMusala += peopleInGroup;
    } else if (peopleInGroup <= 12)
    {
        peopleMonblan += peopleInGroup;
    } else if (peopleInGroup <= 25)
    {
        peopleKilimandjaro += peopleInGroup;
    } else if (peopleInGroup <= 40)
    {
        peopleK2 += peopleInGroup;
    } else if (peopleInGroup >= 41)
    {
        peopleEverest += peopleInGroup;
    }
}

double musala = ((double)peopleMusala / allPeople) * 100;
double monblan = ((double)peopleMonblan / allPeople) * 100;
double kilimandjaro = ((double)peopleKilimandjaro / allPeople) * 100;
double k2 = ((double)peopleK2 / allPeople) * 100;
double everest = ((double)peopleEverest / allPeople) * 100;

Console.WriteLine($"{musala:F2}%");
Console.WriteLine($"{monblan:F2}%");
Console.WriteLine($"{kilimandjaro:F2}%");
Console.WriteLine($"{k2:F2}%");
Console.WriteLine($"{everest:F2}%");