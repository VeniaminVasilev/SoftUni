int inputHours = int.Parse(Console.ReadLine());
int inputMinutes = int.Parse(Console.ReadLine());

int minutes = inputMinutes + 15;
int hours = inputHours;
if (minutes >= 60)
{
    hours += 1;
    minutes = minutes % 60;
}

if (hours > 23)
{
    hours = hours % 24;
}

if (minutes < 10)
{
    Console.WriteLine($"{hours}:0{minutes}");
}
else
{
    Console.WriteLine($"{hours}:{minutes}");
}