int startingChar = int.Parse(Console.ReadLine());
int endingChar = int.Parse(Console.ReadLine());

for (int i = startingChar; i <= endingChar; i++)
{
    Console.Write($"{(char)i} ");
}