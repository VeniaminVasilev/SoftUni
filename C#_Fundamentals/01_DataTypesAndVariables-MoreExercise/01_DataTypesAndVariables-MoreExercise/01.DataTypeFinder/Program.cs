while (true)
{
    string input = Console.ReadLine();

    if (input == "END") { break; }

    if (int.TryParse(input, out int intValue))
    {
        Console.WriteLine($"{input} is integer type");
    }
    else if (float.TryParse(input, out float floatValue))
    {
        Console.WriteLine($"{input} is floating point type");
    }
    else if (char.TryParse(input, out char charValue))
    {
        Console.WriteLine($"{input} is character type");
    }
    else if (bool.TryParse(input, out bool boolValue)) 
    {
         Console.WriteLine($"{input} is boolean type");
    }
    else
    {
        Console.WriteLine($"{input} is string type");
    }
}