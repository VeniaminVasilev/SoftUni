int lastSector = char.Parse(Console.ReadLine()); // 65 to 90 in ASCII
int numberOfRowsSectorA = int.Parse(Console.ReadLine());
int seatsOddRow = int.Parse(Console.ReadLine()); // 97 to 122 in ASCII

int numberOfRowsCurrentSector = numberOfRowsSectorA;
int totalNumberOfSeats = 0;

for (int sector = 65; sector <= lastSector; sector++)
{
    for (int row = 1; row <= numberOfRowsCurrentSector; row++)
    {
        if (row % 2 != 0)
        {
            for (int seat = 97; seat < (97 + seatsOddRow); seat++)
            {
                Console.WriteLine($"{(char)sector}{row}{(char)seat}");
                totalNumberOfSeats++;
            }
        }

        if (row % 2 == 0)
        {
            for (int seat = 97; seat < (97 + seatsOddRow + 2); seat++)
            {
                Console.WriteLine($"{(char)sector}{row}{(char)seat}");
                totalNumberOfSeats++;
            }
        }
    }
    numberOfRowsCurrentSector++;
}
Console.WriteLine(totalNumberOfSeats);