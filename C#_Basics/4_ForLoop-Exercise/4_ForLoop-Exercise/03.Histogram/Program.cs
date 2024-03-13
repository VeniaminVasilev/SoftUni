int n = int.Parse(Console.ReadLine());

int sum1 = 0;
int sum2 = 0;
int sum3 = 0;
int sum4 = 0;
int sum5 = 0;

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());

    if (num < 200)
    {
        sum1 += 1;
    } else if (num >= 200 && num <= 399)
    {
        sum2 += 1;
    } else if (num >= 400 && num <= 599)
    {
        sum3 += 1;
    } else if (num >= 600 && num <= 799)
    {
        sum4 += 1;
    } else if (num >= 800)
    {
        sum5 += 1;
    }
}

double totalSum = sum1 + sum2 + sum3 + sum4 + sum5;
double p1 = (sum1 / totalSum) * 100.0;
double p2 = (sum2 / totalSum) * 100.0;
double p3 = (sum3 / totalSum) * 100.0;
double p4 = (sum4 / totalSum) * 100.0;
double p5 = (sum5 / totalSum) * 100.0;

Console.WriteLine($"{p1:F2}%");
Console.WriteLine($"{p2:F2}%");
Console.WriteLine($"{p3:F2}%");
Console.WriteLine($"{p4:F2}%");
Console.WriteLine($"{p5:F2}%");