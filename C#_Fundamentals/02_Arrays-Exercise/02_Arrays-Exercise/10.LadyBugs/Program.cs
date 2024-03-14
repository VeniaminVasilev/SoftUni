int sizeOfField = int.Parse(Console.ReadLine());

int[] positions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] ladybugsOnField = new int[sizeOfField];

for (int j = 0; j < positions.Length; j++)
{
    int actualBug = positions[j];

    if (actualBug >= 0 && actualBug < ladybugsOnField.Length)
    {
        ladybugsOnField[actualBug] = 1;
    }
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "end") { break; }

    string[] instructions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int position = int.Parse(instructions[0]);
    string direction = instructions[1];
    int flyLength = int.Parse(instructions[2]);

    if (position < 0 || position >= sizeOfField || ladybugsOnField[position] == 0)
    {
        continue;
    }

    if (direction == "left")
    {
        flyLength *= -1;
    }

    bool hasLanded = false;
    ladybugsOnField[position] = 0;

    while (!hasLanded)
    {
        position += flyLength;
        if (position < 0 || position >= sizeOfField)
        {
            break;
        }

        if (ladybugsOnField[position] == 0)
        {
            hasLanded = true;
            ladybugsOnField[position] = 1;
        }
    }
}

Console.WriteLine(string.Join(" ", ladybugsOnField));