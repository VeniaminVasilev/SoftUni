int numberCats = int.Parse(Console.ReadLine());

int group1 = 0;
int group2 = 0;
int group3 = 0;
double gramsAllFood = 0;

for (int i = 0; i < numberCats; i++)
{
    double gramsFood = double.Parse(Console.ReadLine());

    gramsAllFood += gramsFood;

    if (gramsFood < 200) { group1++; }
    else if (gramsFood < 300) { group2++; }
    else if (gramsFood < 400) { group3++; }
}

double priceAllFood = (gramsAllFood / 1000.0) * 12.45;

Console.WriteLine($"Group 1: {group1} cats.");
Console.WriteLine($"Group 2: {group2} cats.");
Console.WriteLine($"Group 3: {group3} cats.");
Console.WriteLine($"Price for food per day: {priceAllFood:F2} lv.");