int n = int.Parse(Console.ReadLine());

int sum = 0;

for (int i = 0; i < n; i++)
{
    int numberToBeAdded = int.Parse(Console.ReadLine());
    sum += numberToBeAdded;
}
Console.WriteLine(sum);