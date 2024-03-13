int n = int.Parse(Console.ReadLine());

int sum = 0;
int maxNumber = int.MinValue;

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    sum += num;
    
    if (num > maxNumber)
    {
        maxNumber = num;
    }
}

int sumWithoutMaxNumber = sum - maxNumber;

if (sumWithoutMaxNumber == maxNumber)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {sumWithoutMaxNumber}");
} else
{
    int difference = Math.Abs(sumWithoutMaxNumber - maxNumber);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {difference}");
}