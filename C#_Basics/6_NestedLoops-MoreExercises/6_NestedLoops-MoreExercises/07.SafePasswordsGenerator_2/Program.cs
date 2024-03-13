int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int maxNumberOfGeneratedPasswords = int.Parse(Console.ReadLine());

int numberA = 35;
int numberB = 64;
int x = 1;
int y = 1;
int passwords = 0;

while (true)
{
    if (passwords > maxNumberOfGeneratedPasswords) { break; }

    if (x > a) { break; }

    while (true)
    {
        if (numberA > 55) { numberA = 35; }
        char charA = (char)numberA;

        if (numberB > 96) { numberB = 64; }
        char charB = (char)numberB;

        if (y > b)
        {
            y = 1;
            break;
        }

        passwords++;

        if (passwords > maxNumberOfGeneratedPasswords) { break; }

        Console.Write($"{charA}{charB}{x}{y}{charB}{charA}|");

        numberA++;
        numberB++;
        y++;
    }

    x++;
}