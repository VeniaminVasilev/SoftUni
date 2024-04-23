//example input "1 2 3 |4 5 6 |  7  8"
List<string> numbersAsStrings = Console.ReadLine()
    .Split('|')
    .Reverse()
    .ToList();

List<int> numbers = new List<int>();

foreach (string sequence in numbersAsStrings)
{
    numbers.AddRange(sequence.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList());
}

// example output "7 8 4 5 6 1 2 3"
Console.WriteLine(string.Join(" ", numbers));