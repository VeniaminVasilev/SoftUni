int degrees = int.Parse(Console.ReadLine());
string time = Console.ReadLine();
string outfit = string.Empty;
string shoes = string.Empty;

if (degrees >= 10 && degrees <= 18)
{
    if (time == "Morning")
    {
        outfit = "Sweatshirt";
        shoes = "Sneakers";
    } else if (time == "Afternoon" || time == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
} else if (degrees > 18 && degrees <= 24)
{
    if (time == "Morning")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    } else if (time == "Afternoon")
    {
        outfit = "T-Shirt";
        shoes = "Sandals";
    } else if (time == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
} else if (degrees >= 25)
{
    if (time == "Morning")
    {
        outfit = "T-Shirt";
        shoes = "Sandals";
    } else if (time == "Afternoon")
    {
        outfit = "Swim Suit";
        shoes = "Barefoot";
    } else if (time == "Evening")
    {
        outfit = "Shirt";
        shoes = "Moccasins";
    }
}
Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");