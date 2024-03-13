int n = int.Parse(Console.ReadLine());

int sumEven = 0;
int sumOdd = 0;

for (int i = 0; i < n; i += 1)
{
    int num = int.Parse(Console.ReadLine());
    if (i % 2 == 0)
    {
        sumEven += num;
    } else
    {
        sumOdd += num;
    }
}

if (sumEven == sumOdd)
{
    Console.WriteLine($"Yes");
    Console.WriteLine($"Sum = {sumEven}");
} else
{
    int difference = Math.Abs(sumEven - sumOdd);
    Console.WriteLine($"No");
    Console.WriteLine($"Diff = {difference}");
}