int kids = 0;
int adults = 0;

while (true)
{
    string command = Console.ReadLine();

    if (command == "Christmas") { break; }

    int age = int.Parse(command);
    
    if (age <= 16) { kids++; }
    if (age > 16) { adults++; }
}

Console.WriteLine($"Number of adults: {adults}");
Console.WriteLine($"Number of kids: {kids}");
Console.WriteLine($"Money for toys: {kids * 5}");
Console.WriteLine($"Money for sweaters: {adults * 15}");