int number = int.Parse(Console.ReadLine());
int firstNumber = int.Parse(number.ToString()[2].ToString());
int secondNumber = int.Parse(number.ToString()[1].ToString());
int thirdNumber = int.Parse(number.ToString()[0].ToString());

for (int i = 1; i <= firstNumber; i++)
{
    for (int j = 1; j <= secondNumber; j++)
    {
        for (int k = 1; k <= thirdNumber; k++)
        {
            Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
        }
    }
}