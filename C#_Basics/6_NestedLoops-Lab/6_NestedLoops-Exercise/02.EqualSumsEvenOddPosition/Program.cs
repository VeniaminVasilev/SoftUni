int startingNumber = int.Parse(Console.ReadLine());
int endingNumber = int.Parse(Console.ReadLine());

for  (int i = startingNumber; i <= endingNumber; i++)
{
    string currentNumber = i.ToString();

    int evenSum = 0;
    int oddSum = 0;

    for (int j = 0; j < currentNumber.Length; j++)
    {
        int number = int.Parse(currentNumber[j].ToString());
        
        if (j % 2 == 0)
        {
            evenSum += number;
        }
        else if (j % 2 == 1)
        {
            oddSum += number;
        }
    }

    if (evenSum == oddSum)
    {
        Console.Write(i + " ");
    }
}