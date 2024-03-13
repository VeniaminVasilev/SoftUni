string breed = Console.ReadLine();
char gender = char.Parse(Console.ReadLine());

int lifeInYears = 0;
bool invalid = false;

if (breed == "British Shorthair" && gender == 'm')
{
    lifeInYears = 13;
} 
else if (breed == "British Shorthair" && gender == 'f')
{
    lifeInYears = 14;
}
else if (breed == "Siamese" && gender == 'm')
{
    lifeInYears = 15;
}
else if (breed == "Siamese" && gender == 'f')
{
    lifeInYears = 16;
}
else if (breed == "Persian" && gender == 'm')
{
    lifeInYears = 14;
}
else if (breed == "Persian" && gender == 'f')
{
    lifeInYears = 15;
}
else if (breed == "Ragdoll" && gender == 'm')
{
    lifeInYears = 16;
}
else if (breed == "Ragdoll" && gender == 'f')
{
    lifeInYears = 17;
}
else if (breed == "American Shorthair" && gender == 'm')
{
    lifeInYears = 12;
}
else if (breed == "American Shorthair" && gender == 'f')
{
    lifeInYears = 13;
}
else if (breed == "Siberian" && gender == 'm')
{
    lifeInYears = 11;
}
else if (breed == "Siberian" && gender == 'f')
{
    lifeInYears = 12;
}
else
{
    invalid = true;
    Console.WriteLine($"{breed} is invalid cat!");
}

double catMonths = Math.Floor((lifeInYears * 12) / 6.0);

if (invalid == false)
{
    Console.WriteLine($"{catMonths} cat months");
}