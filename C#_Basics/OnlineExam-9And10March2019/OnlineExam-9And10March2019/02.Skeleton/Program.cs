int minutesControla = int.Parse(Console.ReadLine());
int secondsControla = int.Parse(Console.ReadLine());
double lengthTrackInMeters = double.Parse(Console.ReadLine());
int secondsFor100Meters = int.Parse(Console.ReadLine());

int allSecondsControla = (minutesControla * 60) + secondsControla;

double secondsFor1Meter = secondsFor100Meters / 100.0;
double reductionOfSeconds = (lengthTrackInMeters / 120.0) * 2.5;
double allSecondsForTrackForMarin = (lengthTrackInMeters * secondsFor1Meter) - reductionOfSeconds;

if (allSecondsForTrackForMarin <= allSecondsControla)
{
    Console.WriteLine($"Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {allSecondsForTrackForMarin:F3}.");
} else
{
    Console.WriteLine($"No, Marin failed! He was {Math.Abs(allSecondsControla - allSecondsForTrackForMarin):F3} second slower.");
}