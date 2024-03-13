string nameOfSerial = Console.ReadLine();
int lengthOfEpizode = int.Parse(Console.ReadLine());
int lengthOfPause = int.Parse(Console.ReadLine());

double timeForLunch = lengthOfPause / 8.0;
double timeForRest = lengthOfPause / 4.0;
double timeLeft = lengthOfPause - timeForLunch - timeForRest;
double difference = Math.Abs(timeLeft - lengthOfEpizode);
difference = Math.Ceiling(difference);

if (timeLeft >= lengthOfEpizode)
{
    Console.WriteLine($"You have enough time to watch {nameOfSerial} and left with {difference} minutes free time.");
} else
{
    Console.WriteLine($"You don't have enough time to watch {nameOfSerial}, you need {difference} more minutes.");
}