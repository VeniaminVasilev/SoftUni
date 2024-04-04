static void PrintAllTopIntegersInTheRange(int endValue)
{
    for (int i = 8; i <= endValue; i++)
    {
        bool isTopInteger = true;
        bool haveOddNumber = false;
        string currentNumberToString = i.ToString();
        int currentSumOfDigits = 0;

        for (int j = 0; j < currentNumberToString.Length; j++)
        {
            currentSumOfDigits += currentNumberToString[j];

            if (currentNumberToString[j] % 2 == 1)
            {
                haveOddNumber = true;
            }
        }

        if (currentSumOfDigits % 8 != 0)
        {
            isTopInteger = false;
        }

        if (isTopInteger && haveOddNumber)
        {
            Console.WriteLine(i);
        }
    }
}

int endValue = int.Parse(Console.ReadLine());
PrintAllTopIntegersInTheRange(endValue);