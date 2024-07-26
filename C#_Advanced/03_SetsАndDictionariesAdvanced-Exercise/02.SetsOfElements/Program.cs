int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int n = numbers[0];
int m = numbers[1];

HashSet<int> set1 = new HashSet<int>();
HashSet<int> set2 = new HashSet<int>();
HashSet<int> uniqueNumbers = new HashSet<int>();

for (int i = 0; i < n; i++)
{
    set1.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < m; i++)
{
    set2.Add(int.Parse(Console.ReadLine()));
}

foreach (int number in set1)
{
    foreach (int number2 in set2)
    {
        if (number == number2)
        {
            uniqueNumbers.Add(number);
        }
    }
}

Console.WriteLine(string.Join(" ", uniqueNumbers));