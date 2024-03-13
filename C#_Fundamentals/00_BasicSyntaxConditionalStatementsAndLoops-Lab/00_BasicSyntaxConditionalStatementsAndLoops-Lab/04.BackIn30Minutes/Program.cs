using System.ComponentModel.Design;

int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

int timeInMinutes = hours * 60 + minutes;
int timePlus30Minutes = timeInMinutes + 30;

int updatedHours = 0;
int updatedMinutes = 0;

if (timePlus30Minutes > 1439)
{
    updatedMinutes = timePlus30Minutes - 1440;

    if (updatedMinutes < 10)
    {
        Console.WriteLine($"0:0{updatedMinutes}");
    }
    else
    {
        Console.WriteLine($"0:{updatedMinutes}");
    }
}
else
{
    updatedHours = timePlus30Minutes / 60;
    updatedMinutes = timePlus30Minutes % 60;

    if (updatedMinutes < 10)
    {
        Console.WriteLine($"{updatedHours}:0{updatedMinutes}");
    }
    else
    {
        Console.WriteLine($"{updatedHours}:{updatedMinutes}");
    }
}