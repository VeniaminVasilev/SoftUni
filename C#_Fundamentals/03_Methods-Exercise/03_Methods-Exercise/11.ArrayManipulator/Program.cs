int[] array = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

while (true)
{
    string command = Console.ReadLine();
    if (command == "end")
    {
        Console.Write($"[{String.Join(", ", array)}]");
        break;
    }

    string[] commandArray = command.Split().ToArray();

    if (commandArray[0] == "exchange")
    {
        int index = int.Parse(commandArray[1]);

        if (index > array.Length - 1 || index < 0)
        {
            Console.WriteLine($"Invalid index");
            continue; 
        }

        array = ExchangePlacesOfElementsInArray(array, index);
    }
    else if (command == "max even")
    {
        PrintIndexOfMaxEvenNumber(array);
    }
    else if (command == "max odd")
    {
        PrintIndexOfMaxOddNumber(array);
    }
    else if (command == "min even")
    {
        PrintIndexOfMinEvenNumber(array);
    }
    else if (command == "min odd")
    {
        PrintIndexOfMinOddNumber(array);
    }
    else if (commandArray[0] == "first" && commandArray[2] == "even")
    {
        PrintFirstEvenNumbers(array, int.Parse(commandArray[1]));
    }
    else if (commandArray[0] == "first" && commandArray[2] == "odd")
    {
        PrintFirstOddNumbers(array, int.Parse(commandArray[1]));
    }
    else if (commandArray[0] == "last" && commandArray[2] == "even")
    {
        PrintLastEvenNumbers(array, int.Parse(commandArray[1]));
    }
    else if (commandArray[0] == "last" && commandArray[2] == "odd")
    {
        PrintLastOddNumbers(array, int.Parse(commandArray[1]));
    }
}

static void PrintFirstEvenNumbers(int[] array, int count)
{
    if (count > array.Length || count <= 0)
    {
        Console.WriteLine("Invalid count");
    }
    else
    {
        int[] array1 = new int[count];
        int currentPositonInArray1 = 0;
        int numbersInArray2 = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                array1[currentPositonInArray1] = array[i];
                currentPositonInArray1++;
                numbersInArray2++;
            }

            if (currentPositonInArray1 == count)
            {
                break;
            }
        }

        int[] array2 = new int[numbersInArray2];

        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = array1[i];
        }

        Console.Write("[");

        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i]);
            if (i < array2.Length - 1) { Console.Write(", "); }
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

static void PrintFirstOddNumbers(int[] array, int count)
{
    if (count > array.Length)
    {
        Console.WriteLine("Invalid count");
    }
    else
    {
        int[] array1 = new int[count];
        int currentPositonInArray1 = 0;
        int numbersInArray2 = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 != 0)
            {
                array1[currentPositonInArray1] = array[i];
                currentPositonInArray1++;
                numbersInArray2++;
            }

            if (currentPositonInArray1 == count)
            {
                break;
            }
        }

        int[] array2 = new int[numbersInArray2];

        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = array1[i];
        }

        Console.Write("[");

        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i]);
            if (i < array2.Length - 1) { Console.Write(", "); }
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

static void PrintLastEvenNumbers(int[] array, int count)
{
    if (count > array.Length)
    {
        Console.WriteLine("Invalid count");
    }
    else
    {
        int[] array1 = new int[count];
        int currentPositonInArray1 = 0;
        int numbersInArray2 = 0;

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 == 0)
            {
                array1[currentPositonInArray1] = array[i];
                currentPositonInArray1++;
                numbersInArray2++;
            }

            if (currentPositonInArray1 == count)
            {
                break;
            }
        }

        int[] array2 = new int[numbersInArray2];

        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = array1[i];
        }

        Console.Write("[");

        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i]);
            if (i < array2.Length - 1) { Console.Write(", "); }
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

static void PrintLastOddNumbers(int[] array, int count)
{
    if (count > array.Length)
    {
        Console.WriteLine("Invalid count");
    }
    else
    {
        int[] array1 = new int[count];
        int currentPositonInArray1 = 0;
        int numbersInArray2 = 0;

        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 != 0)
            {
                array1[currentPositonInArray1] = array[i];
                currentPositonInArray1++;
                numbersInArray2++;
            }

            if (currentPositonInArray1 == count)
            {
                break;
            }
        }

        int[] array2 = new int[numbersInArray2];

        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = array1[i];
        }

        Console.Write("[");

        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i]);
            if (i < array2.Length - 1) { Console.Write(", "); }
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

static void PrintIndexOfMaxEvenNumber(int[] array)
{
    int maxEvenNumber = int.MinValue;
    int maxIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > maxEvenNumber && array[i] % 2 == 0)
        {
            maxEvenNumber = array[i];
            maxIndex = i;
        }
        else if (array[i] == maxEvenNumber)
        {
            maxIndex = i;
        }
    }

    if (maxEvenNumber != int.MinValue)
    {
        Console.WriteLine(maxIndex);
    }
    else
    {
        Console.WriteLine("No matches");
    }
}

static void PrintIndexOfMaxOddNumber(int[] array)
{
    int maxOddNumber = int.MinValue;
    int maxIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > maxOddNumber && array[i] % 2 != 0)
        {
            maxOddNumber = array[i];
            maxIndex = i;
        }
        else if (array[i] == maxOddNumber)
        {
            maxIndex = i;
        }
    }

    if (maxOddNumber != int.MinValue)
    {
        Console.WriteLine(maxIndex);
    }
    else
    {
        Console.WriteLine("No matches");
    }
}

static void PrintIndexOfMinEvenNumber(int[] array)
{
    int minEvenNumber = int.MaxValue;
    int minIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < minEvenNumber && array[i] % 2 == 0)
        {
            minEvenNumber = array[i];
            minIndex = i;
        }
        else if (array[i] == minEvenNumber)
        {
            minIndex = i;
        }
    }

    if (minEvenNumber != int.MaxValue)
    {
        Console.WriteLine(minIndex);
    }
    else
    {
        Console.WriteLine("No matches");
    }
}

static void PrintIndexOfMinOddNumber(int[] array)
{
    int minOddNumber = int.MaxValue;
    int minIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < minOddNumber && array[i] % 2 != 0)
        {
            minOddNumber = array[i];
            minIndex = i;
        }
        else if (array[i] == minOddNumber)
        {
            minIndex = i;
        }
    }

    if (minOddNumber != int.MaxValue)
    {
        Console.WriteLine(minIndex);
    }
    else
    {
        Console.WriteLine("No matches");
    }
}

static int[] ExchangePlacesOfElementsInArray(int[] array, int index)
{
    int[] array1 = new int[index + 1];
    int[] array2 = new int[array.Length - (index + 1)];

    for (int i = 0; i < array1.Length; i++)
    {
        array1[i] = array[i];
    }

    for (int j = 0; j < array2.Length; j++)
    {
        array2[j] = array[j + index + 1];
    }

    for (int i = 0; i < array2.Length; i++)
    {
        array[i] = array2[i];
    }

    for (int i = array2.Length; i < array.Length; i++)
    {
        array[i] = array1[i - array2.Length];
    }

    return array;
}