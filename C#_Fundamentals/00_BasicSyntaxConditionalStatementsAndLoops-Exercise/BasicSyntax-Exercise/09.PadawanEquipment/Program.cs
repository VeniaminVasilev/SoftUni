double amountOfMoney = double.Parse(Console.ReadLine());
int countOfStudents = int.Parse(Console.ReadLine());
double priceSaber = double.Parse(Console.ReadLine());
double priceRobe = double.Parse(Console.ReadLine());
double priceBelt = double.Parse(Console.ReadLine());

double priceAllSabers = (Math.Ceiling(countOfStudents * 1.10)) * priceSaber;
double priceAllRobes = priceRobe * countOfStudents;
double priceAllBelts = priceBelt * (countOfStudents - (countOfStudents / 6));
double allCosts = priceAllSabers + priceAllRobes + priceAllBelts;

if (amountOfMoney >= allCosts)
{
    Console.WriteLine($"The money is enough - it would cost {allCosts:F2}lv.");
}
else
{
    Console.WriteLine($"John will need {allCosts - amountOfMoney:F2}lv more.");
}