List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

list.RemoveAll(n => n < 0);

if (list.Count == 0)
{
    Console.WriteLine("empty");
}
else
{
    for (int i = list.Count - 1; i >= 0; i--)
    {
        Console.Write($"{list[i]} ");
    }
}