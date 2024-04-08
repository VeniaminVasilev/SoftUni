namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            if (dataType == "int")
            {
                int number = int.Parse(Console.ReadLine());
                ExecuteProgram(number);
            }
            else if (dataType == "real")
            {
                double doubleNumber = double.Parse(Console.ReadLine());
                ExecuteProgram(doubleNumber);
            }
            else if (dataType == "string")
            {
                string text = Console.ReadLine();
                ExecuteProgram(text);
            }
        }

        static void ExecuteProgram(int number)
        {
            Console.WriteLine(number * 2);
        }

        static void ExecuteProgram(double number)
        {
            Console.WriteLine($"{number * 1.50:F2}");
        }

        static void ExecuteProgram(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
