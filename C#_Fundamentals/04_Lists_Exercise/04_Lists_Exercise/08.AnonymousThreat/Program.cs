List<string> list = Console.ReadLine().Split(' ').ToList();
string line = "";
while ((line = Console.ReadLine()) != "3:1")
{
    string[] data = line.Split(' ');
    if (data[0] == "merge")
    {
        int start = int.Parse(data[1]);
        int end = int.Parse(data[2]);
        if (start < 0) start = 0;
        if (end >= list.Count) end = list.Count - 1;
        for (int difference = end - start; difference > 0; --difference)
        {
            list[start] += list[start + 1];
            list.RemoveAt(start + 1);
        }
    }

    if (data[0] == "divide")
    {
        int index = int.Parse(data[1]);
        int partitions = int.Parse(data[2]);

        int partSize = list[index].Length / partitions;
        int counter = partitions;
        int off = 1;

        while (counter > 1)
        {
            counter--;
            list.Insert(index + off, new string(list[index].Take(partSize).ToArray()));
            off++;
            list[index] = new string(list[index].Skip(partSize).ToArray());
        }
        list.Insert(index + off, list[index]);
        list.RemoveAt(index);
    }
}

Console.WriteLine(string.Join(' ', list));