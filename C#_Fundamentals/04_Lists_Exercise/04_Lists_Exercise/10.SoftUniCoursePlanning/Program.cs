List<string> list = Console.ReadLine()
    .Split(", ")
    .ToList();

while (true)
{
    string command = Console.ReadLine();

    if (command == "course start")
    {
        break;
    }

    string[] tokens = command.Split(":");

    if (tokens[0] == "Add" && !list.Contains($"{tokens[1]}"))
    {
        list.Add(tokens[1]);
    }
    else if (tokens[0] == "Insert" && !list.Contains($"{tokens[1]}"))
    {
        list.Insert(int.Parse(tokens[2]), tokens[1]);
    }
    else if (tokens[0] == "Remove" && list.Contains($"{tokens[1]}"))
    {
        list.Remove(tokens[1]);
    }
    else if (tokens[0] == "Swap" && list.Contains($"{tokens[1]}") && list.Contains($"{tokens[2]}"))
    {
        string lesson1 = tokens[1];
        string lesson2 = tokens[2];
        int indexOfLesson1 = list.IndexOf(lesson1);
        int indexOfLesson2 = list.IndexOf(lesson2);

        list.RemoveAt(indexOfLesson1);
        list.Insert(indexOfLesson1, lesson2);

        if (list.Contains($"{lesson2}-Exercise"))
        {
            list.Remove($"{lesson2}-Exercise");
            list.Insert(indexOfLesson1 + 1, $"{lesson2}-Exercise");

            list.RemoveAt(indexOfLesson2 + 1);
            list.Insert(indexOfLesson2 + 1, lesson1);
        }
        else
        {
            list.RemoveAt(indexOfLesson2);
            list.Insert(indexOfLesson2, lesson1);
        }

        if (list.Contains($"{lesson1}-Exercise"))
        {
            list.Remove($"{lesson1}-Exercise");
            list.Insert(indexOfLesson2 + 1, $"{lesson1}-Exercise");
        }
    }
    else if (tokens[0] == "Exercise")
    {
        string lessonTitle = tokens[1];

        if (list.Contains(lessonTitle) && !list.Contains($"{lessonTitle}-Exercise"))
        {
            int indexOfLesson = list.IndexOf(lessonTitle);
            list.Insert(indexOfLesson + 1, $"{lessonTitle}-Exercise");
        }
        else if (!list.Contains(lessonTitle) && !list.Contains($"{lessonTitle}-Exercise"))
        {
            list.Add(lessonTitle);
            list.Add($"{lessonTitle}-Exercise");
        }
    }
}

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine($"{i + 1}.{list[i]}");
}