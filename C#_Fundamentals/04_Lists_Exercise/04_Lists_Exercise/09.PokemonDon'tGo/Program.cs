List<int> list = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

int sum = 0;

while (true)
{
    bool indexSmallerThan0 = false;
    bool indexGreaterThenList = false;
    int indexOfElementToBeRemoved = int.Parse(Console.ReadLine());

    if (indexOfElementToBeRemoved < 0)
    {
        indexOfElementToBeRemoved = 0;
        indexSmallerThan0 = true;
    } else if (indexOfElementToBeRemoved >= list.Count)
    {
        indexOfElementToBeRemoved = list.Count - 1;
        indexGreaterThenList = true;
    }

    int elementToBeRemoved = list[indexOfElementToBeRemoved];

    sum += elementToBeRemoved;
    list.RemoveAt(indexOfElementToBeRemoved);

    if (list.Count == 0) { break; }

    if (indexSmallerThan0)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] <= elementToBeRemoved)
            {
                list[i] += elementToBeRemoved;
            }
            else
            {
                list[i] -= elementToBeRemoved;
            }
        }

        list.Insert(0, list[list.Count - 1]);
    }
    else if (indexGreaterThenList)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] <= elementToBeRemoved)
            {
                list[i] += elementToBeRemoved;
            }
            else
            {
                list[i] -= elementToBeRemoved;
            }
        }

        list.Add(list[0]);
    }
    else
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] <= elementToBeRemoved)
            {
                list[i] += elementToBeRemoved;
            }
            else
            {
                list[i] -= elementToBeRemoved;
            }
        }
    }
}

Console.WriteLine(sum);