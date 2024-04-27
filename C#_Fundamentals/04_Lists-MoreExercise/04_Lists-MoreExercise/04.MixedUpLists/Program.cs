List<int> list1 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

List<int> list2 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

List<int> resultList = new List<int>();

int count = Math.Min(list1.Count, list2.Count);

for (int i = 0; i < count; i++)
{
    resultList.Add(list1[i]);
    resultList.Add(list2[list2.Count - i - 1]);
}

int max = 0;
int min = 0;

if (list1.Count > list2.Count)
{
    if (list1[list1.Count - 2] > list1[list1.Count - 1])
    {
        max = list1[list1.Count - 2];
        min = list1[list1.Count - 1];
    }
    else
    {
        min = list1[list1.Count - 2];
        max = list1[list1.Count - 1];
    }
}
else
{
    if (list2[1] > list2[0])
    {
        max = list2[1];
        min = list2[0];
    }
    else
    {
        min = list2[1];
        max = list2[0];
    }
}

List<int> finalList = new List<int>();

for (int i = 0; i < resultList.Count; i++)
{
    if (resultList[i] < max && resultList[i] > min)
    {
        finalList.Add(resultList[i]);
    }
}

finalList.Sort();

Console.WriteLine(string.Join(" ", finalList));