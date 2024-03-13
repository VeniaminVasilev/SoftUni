int n = int.Parse(Console.ReadLine());

int counter = 1;
bool isBigger = false;

for (int rows = 1; rows <= n; rows++)
{
    for (int columns = 1; columns <= rows; columns++)
    {
        if (counter > n)
        {
            isBigger = true;
            break;
        }

        Console.Write(counter + " ");
        counter++;
    }

    if (isBigger)
    {
        break;
    }

    Console.WriteLine();
}