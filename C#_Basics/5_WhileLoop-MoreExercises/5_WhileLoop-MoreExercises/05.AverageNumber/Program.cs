int n = int.Parse(Console.ReadLine());
int sum = 0;
int counter = 0;
for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    sum += currentNumber;
    counter++;
}
Console.WriteLine($"{(double)sum / counter:F2}");