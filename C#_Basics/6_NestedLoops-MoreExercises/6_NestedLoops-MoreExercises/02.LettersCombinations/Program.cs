int start = char.Parse(Console.ReadLine());
int end = char.Parse(Console.ReadLine());
int miss = char.Parse(Console.ReadLine());

int combinations = 0;

for (int a = start; a <= end; a++)
{
    if (a == miss) { continue; }

	for (int b = start; b <= end; b++)
	{
        if (b == miss) { continue; }

        for (int c = start; c <= end; c++)
        {
            if (c == miss) { continue; }

            combinations++;

            char characterA = (char)a;
            char characterB = (char)b;
            char characterC = (char)c;

            Console.Write($"{characterA}{characterB}{characterC} ");
        }
    }
}
Console.Write(combinations);