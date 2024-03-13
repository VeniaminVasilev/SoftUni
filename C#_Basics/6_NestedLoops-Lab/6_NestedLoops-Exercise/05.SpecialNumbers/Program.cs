int n = int.Parse(Console.ReadLine());

for  (int i = 1111; i <= 9999; i++)
{
    string number = i.ToString();

    bool isSpecial = true;

    for (int j = 0; j < number.Length; j++)
    {
        int currentDigit = int.Parse(number[j].ToString());

        if (currentDigit == 0)
        {
            isSpecial = false;
            break;
        }

        if (n % currentDigit != 0)
        {
            isSpecial = false;
            break;
        }
    }

    if (isSpecial)
    {
        Console.Write(i + " ");
    }
}