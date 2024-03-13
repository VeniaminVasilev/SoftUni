int width = int.Parse(Console.ReadLine());
int length = int.Parse(Console.ReadLine());
int heigth = int.Parse(Console.ReadLine());
int freeSpace = width * length * heigth;

while (true)
{
    string command = Console.ReadLine();

    if (command == "Done")
    {
        Console.WriteLine($"{freeSpace} Cubic meters left.");
        break;
    }

    int boxes = int.Parse(command);
    freeSpace -= boxes;

    if (freeSpace < 0)
    {
        Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
        break;
    }
}