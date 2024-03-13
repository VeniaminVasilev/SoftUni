int hourExam = int.Parse(Console.ReadLine());
int minuteExam = int.Parse(Console.ReadLine());
int hourArrival = int.Parse(Console.ReadLine());
int minuteArrival = int.Parse(Console.ReadLine());

int examInMinutes = (hourExam * 60) + minuteExam;
int arrivalInMinutes = (hourArrival * 60) + minuteArrival;

if (arrivalInMinutes < (examInMinutes - 30))
{
    Console.WriteLine("Early");
    if ((examInMinutes - arrivalInMinutes) > 59)
    {
        int hour = (examInMinutes - arrivalInMinutes) / 60;
        int minutes = (examInMinutes - arrivalInMinutes) % 60;
        if (minutes < 10)
        {
            Console.WriteLine($"{hour}:0{minutes} hours before the start");
        } else
        {
            Console.WriteLine($"{hour}:{minutes} hours before the start");
        }
    } else
    {
        Console.WriteLine($"{examInMinutes - arrivalInMinutes} minutes before the start");
    }
} else if (arrivalInMinutes < examInMinutes)
{
    Console.WriteLine("On time");
    Console.WriteLine($"{examInMinutes - arrivalInMinutes} minutes before the start");
} else if (arrivalInMinutes == examInMinutes)
{
    Console.WriteLine("On time");
} else if (arrivalInMinutes > examInMinutes)
{
    Console.WriteLine("Late");
    if ((arrivalInMinutes - examInMinutes) > 59)
    {
        int hour = (arrivalInMinutes - examInMinutes) / 60;
        int minutes = (arrivalInMinutes - examInMinutes) % 60;
        if (minutes < 10)
        {
            Console.WriteLine($"{hour}:0{minutes} hours after the start");
        }
        else
        {
            Console.WriteLine($"{hour}:{minutes} hours after the start");
        }
    }
    else
    {
        Console.WriteLine($"{arrivalInMinutes - examInMinutes} minutes after the start");
    }
}