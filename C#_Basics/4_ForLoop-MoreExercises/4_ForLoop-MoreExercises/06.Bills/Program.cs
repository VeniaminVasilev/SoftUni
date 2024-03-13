int months = int.Parse(Console.ReadLine());

double electricityBills = 0;
double waterBills = months * 20.0;
double internetBills = months * 15.0;
double otherBills = 0;

for (int i = 0; i < months; i++)
{
    double billElectricity = double.Parse(Console.ReadLine());
    electricityBills += billElectricity;
    otherBills += (billElectricity + 20 + 15) * 1.20;
}

double averageBills = (electricityBills + waterBills + internetBills + otherBills) / months;

Console.WriteLine($"Electricity: {electricityBills:F2} lv");
Console.WriteLine($"Water: {waterBills:F2} lv");
Console.WriteLine($"Internet: {internetBills:F2} lv");
Console.WriteLine($"Other: {otherBills:F2} lv");
Console.WriteLine($"Average: {averageBills:F2} lv");