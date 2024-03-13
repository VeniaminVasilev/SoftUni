int maxNumber1 = int.Parse(Console.ReadLine());
int maxNumber2 = int.Parse(Console.ReadLine());
int maxNumber3 = int.Parse(Console.ReadLine());

for  (int i = 2; i <= maxNumber1; i+=2)
{
    int number1 = 0;
    
    if (i % 2 == 0)
    {
        number1 = i;
    } else
    {
        number1 = (i / 2) * 2;
    }

    for (int j = 2; j <= maxNumber2; j++)
    {
        int number2 = 0;
        if (j == 2)
        {
            number2 = j;
        }
        else if (j == 3)
        {
            number2 = j;
        }
        else if (j == 5)
        {
            number2 = j;
        }
        else if (j == 7)
        {
            number2 = j;
        } 
        else
        {
            continue;
        }

        for (int k = 2; k <= maxNumber3; k+=2)
        {
            int number3 = 0;

            if (k % 2 == 0)
            {
                number3 = k;
            } else
            {
                number3 = (k / 2) * 2;
            }

            Console.WriteLine($"{number1} {number2} {number3}");
        }
    }
}