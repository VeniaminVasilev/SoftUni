int days = int.Parse(Console.ReadLine());
int kilogramsLeftByMarina = int.Parse(Console.ReadLine());
double kgFoodPerDayForDog = double.Parse(Console.ReadLine());
double kgFoodPerDayForCat = double.Parse(Console.ReadLine());
double gramsFoodPerDayForTurtle = double.Parse(Console.ReadLine());

double neededFoodForDog = kgFoodPerDayForDog * days;
double neededFoodForCat = kgFoodPerDayForCat * days;
double neededFoodForTurtle = (gramsFoodPerDayForTurtle / 1000) * days;
double neededFood = neededFoodForDog + neededFoodForCat + neededFoodForTurtle;
double difference = Math.Abs(neededFood - kilogramsLeftByMarina);

if (kilogramsLeftByMarina >= neededFood)
{
    Console.WriteLine($"{Math.Floor(difference)} kilos of food left.");
} else
{
    Console.WriteLine($"{Math.Ceiling(difference)} more kilos of food are needed.");
}