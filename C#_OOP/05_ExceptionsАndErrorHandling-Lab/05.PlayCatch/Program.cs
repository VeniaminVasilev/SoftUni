namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int handledExceptions = 0;

            while (true)
            {
                if (handledExceptions == 3)
                {
                    Console.WriteLine(string.Join(", ", integers));
                    break;
                }

                string[] commands = Console.ReadLine().Split(" ");
                string action = commands[0];

                if (action == "Replace")
                {
                    try
                    {
                        int index = int.Parse(commands[1]);

                        if (index < 0 || index >= integers.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        int element = int.Parse(commands[2]);

                        integers[index] = element;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        handledExceptions++;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        handledExceptions++;
                    }
                }
                else if (action == "Print")
                {
                    try
                    {
                        int startIndex = int.Parse(commands[1]);

                        if (startIndex < 0 || startIndex >= integers.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        int endIndex = int.Parse(commands[2]);

                        if (endIndex < 0 || endIndex >= integers.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        Console.WriteLine(string.Join(", ", integers.Skip(startIndex).Take(endIndex - startIndex + 1)));

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        handledExceptions++;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        handledExceptions++;
                    }
                }
                else if (action == "Show")
                {
                    try
                    {
                        int index = int.Parse(commands[1]);

                        if (index < 0 || index >= integers.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        Console.WriteLine(integers[index]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        handledExceptions++;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        handledExceptions++;
                    }
                }
            }
        }
    }
}