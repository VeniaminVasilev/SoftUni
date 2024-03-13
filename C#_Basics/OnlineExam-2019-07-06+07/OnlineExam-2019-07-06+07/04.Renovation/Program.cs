int height = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int percentWindows = int.Parse(Console.ReadLine());

double metersForPainting = height * width * 4.0;
metersForPainting = Math.Ceiling(metersForPainting - (metersForPainting * (percentWindows / 100.0)));

int paintedMeters = 0;

while (true)
{
    string command = Console.ReadLine();
    
    if (command == "Tired!")
    {
        Console.WriteLine($"{metersForPainting - paintedMeters} quadratic m left.");
        break;
    }

    int litersPaint = int.Parse(command);

    paintedMeters += litersPaint;

    if (paintedMeters > metersForPainting)
    {
        Console.WriteLine($"All walls are painted and you have {paintedMeters - metersForPainting} l paint left!");
        break;
    }

    if (paintedMeters == metersForPainting)
    {
        Console.WriteLine($"All walls are painted! Great job, Pesho!");
        break;
    }
}