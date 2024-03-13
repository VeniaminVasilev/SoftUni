string country = Console.ReadLine();
string discipline = Console.ReadLine();

double evaluation = 0;

if (country == "Russia" && discipline == "ribbon")
{
    evaluation = 9.100 + 9.400;
}
else if (country == "Russia" && discipline == "hoop")
{
    evaluation = 9.300 + 9.800;
}
else if (country == "Russia" && discipline == "rope")
{
    evaluation = 9.600 + 9.000;
}
else if (country == "Bulgaria" && discipline == "ribbon")
{
    evaluation = 9.600 + 9.400;
}
else if (country == "Bulgaria" && discipline == "hoop")
{
    evaluation = 9.550 + 9.750;
}
else if (country == "Bulgaria" && discipline == "rope")
{
    evaluation = 9.500 + 9.400;
}
else if (country == "Italy" && discipline == "ribbon")
{
    evaluation = 9.200 + 9.500;
}
else if (country == "Italy" && discipline == "hoop")
{
    evaluation = 9.450 + 9.350;
}
else if (country == "Italy" && discipline == "rope")
{
    evaluation = 9.700 + 9.150;
}

double percentNeededForUltimateVictory = ((20 - evaluation) / 20) * 100;

Console.WriteLine($"The team of {country} get {evaluation:F3} on {discipline}.");
Console.WriteLine($"{percentNeededForUltimateVictory:F2}%");