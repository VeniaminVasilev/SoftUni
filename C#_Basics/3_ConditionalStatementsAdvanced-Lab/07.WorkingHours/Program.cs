int hour = int.Parse(Console.ReadLine());
string day = Console.ReadLine();

if (hour >= 10 && hour <= 18)
{
    switch (day)
    {
        case "Monday": Console.WriteLine("open"); break;
        case "Tuesday": Console.WriteLine("open"); break;
        case "Wednesday": Console.WriteLine("open"); break;
        case "Thursday": Console.WriteLine("open"); break;
        case "Friday": Console.WriteLine("open"); break;
        case "Saturday": Console.WriteLine("open"); break;
        case "Sunday": Console.WriteLine("closed"); break;
    } 
} else
{
    Console.WriteLine("closed");
}