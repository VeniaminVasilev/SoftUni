int startingNumber = int.Parse(Console.ReadLine());
int endingNumber = int.Parse(Console.ReadLine());

for (int number1 = startingNumber; number1 <= endingNumber; number1++)
{
    for (int number2 = startingNumber; number2 <= endingNumber; number2++)
    {
        for (int number3 = startingNumber; number3 <= endingNumber; number3++)
        {
            for (int number4 = startingNumber; number4 <= endingNumber; number4++)
            {
                if (number1 % 2 == 0 && number4 % 2 == 0) { continue; }

                if (number1 % 2 != 0 && number4 % 2 != 0) { continue; }

                if (number1 <= number4) { continue; }

                if ((number2 + number3) % 2 != 0) { continue; }

                Console.Write($"{number1}{number2}{number3}{number4} ");
            }
        }
    }
}