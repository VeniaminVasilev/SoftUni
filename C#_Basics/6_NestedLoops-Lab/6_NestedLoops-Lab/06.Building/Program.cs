int floors = int.Parse(Console.ReadLine());
int rooms = int.Parse(Console.ReadLine());

for (int currentFloor = floors; currentFloor > 0; currentFloor--)
{
    for (int currentRoom = 0; currentRoom < rooms; currentRoom++)
    {
        if (currentFloor == floors)
        {
            Console.Write($"L{currentFloor}{currentRoom} ");
        }
        else if (currentFloor % 2 == 1)
        {
            Console.Write($"A{currentFloor}{currentRoom} ");
        }
        else if (currentFloor % 2 == 0)
        {
            Console.Write($"O{currentFloor}{currentRoom} ");
        }
    }
    Console.WriteLine();
}