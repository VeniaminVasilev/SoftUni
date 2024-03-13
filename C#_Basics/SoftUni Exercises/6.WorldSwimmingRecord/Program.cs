double recordInSeconds = double.Parse(Console.ReadLine());
double distanceInMeters = double.Parse(Console.ReadLine());
double timeInSecondsFor1Meter = double.Parse(Console.ReadLine());

double delayInSeconds = Math.Floor(distanceInMeters / 15) * 12.50;
double secondsForDistanceForIvan = (timeInSecondsFor1Meter * distanceInMeters) + delayInSeconds;
double difference = Math.Abs(recordInSeconds - secondsForDistanceForIvan);

if (secondsForDistanceForIvan < recordInSeconds)
{
    Console.WriteLine($"Yes, he succeeded! The new world record is {secondsForDistanceForIvan:F2} seconds.");
} else
{
    Console.WriteLine($"No, he failed! He was {difference:F2} seconds slower.");
}