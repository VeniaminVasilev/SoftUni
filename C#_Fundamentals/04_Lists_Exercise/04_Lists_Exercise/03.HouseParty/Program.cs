int commands = int.Parse(Console.ReadLine());
List<string> guests = new List<string>();

for (int i = 0; i < commands; i++)
{
    // commands are like these: "{name} is going!" or "{name} is not going!"
    string[] currentCommand = Console.ReadLine().Split();
    
    if (currentCommand.Length == 3) //"{name} is going!"
    {
        if (guests.Contains($"{currentCommand[0]}"))
        {
            Console.WriteLine($"{currentCommand[0]} is already in the list!");
        }
        else
        {
            guests.Add(currentCommand[0]);
        }
    }
    else if (currentCommand.Length == 4) //"{name} is not going!"
    {
        if (guests.Contains($"{currentCommand[0]}"))
        {
            guests.Remove(currentCommand[0]);
        }
        else
        {
            Console.WriteLine($"{currentCommand[0]} is not in the list!");
        }
    }
}

for (int i = 0; i < guests.Count; i++)
{
    Console.WriteLine(guests[i]);
}