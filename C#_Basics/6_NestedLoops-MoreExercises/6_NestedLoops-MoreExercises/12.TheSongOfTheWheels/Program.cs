int controlValueM = int.Parse(Console.ReadLine());

int printedNumbers = 0;
string password = string.Empty;
bool passwordFound = false;

for (int a = 1; a <= 9; a++)
{
    for (int b = 1; b <= 9; b++)
    {
        for (int c = 1; c <= 9; c++)
        {
            for (int d = 1; d <= 9; d++)
            {
                if (a < b && c > d && (a*b + c*d == controlValueM))
                {
                    printedNumbers++;
                    Console.Write($"{a}{b}{c}{d} ");
                }

                if (printedNumbers == 4 && passwordFound == false)
                {
                    password = $"{a}{b}{c}{d}";
                    passwordFound = true;
                }
            }
        }
    }
}

Console.WriteLine();
if (passwordFound == true)
{
    Console.WriteLine($"Password: {password}");
}

if (password == string.Empty)
{
    Console.WriteLine("No!");
}