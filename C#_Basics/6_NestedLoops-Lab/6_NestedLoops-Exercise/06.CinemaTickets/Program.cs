int totalTickets = 0;
int studentTickets = 0;
int standardTickets = 0;
int kidTickets = 0;

while (true)
{
    string command = Console.ReadLine();
    if (command == "Finish")
    {
        break;
    }

    int availablePositions = int.Parse(Console.ReadLine());
    int occupiedPositions = 0;

    while (occupiedPositions < availablePositions)
    {
        string ticketType = Console.ReadLine();
        if (ticketType == "End")
        {
            break;
        }
        else if (ticketType == "student")
        {
            totalTickets++;
            studentTickets++;
            occupiedPositions++;
        }
        else if (ticketType == "standard")
        {
            totalTickets++;
            standardTickets++;
            occupiedPositions++;
        }
        else if (ticketType == "kid")
        {
            totalTickets++;
            kidTickets++;
            occupiedPositions++;
        }
    }

    Console.WriteLine($"{command} - {((double)occupiedPositions / availablePositions) * 100:F2}% full.");
}

Console.WriteLine($"Total tickets: {totalTickets}");
Console.WriteLine($"{((double)studentTickets / totalTickets) * 100:F2}% student tickets.");
Console.WriteLine($"{((double)standardTickets / totalTickets) * 100:F2}% standard tickets.");
Console.WriteLine($"{((double)kidTickets / totalTickets) * 100:F2}% kids tickets.");