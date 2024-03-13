int n = int.Parse(Console.ReadLine());

double numberOfSales = 0;
double sumOfRatings = 0;

for (int i = 1; i <= n; i++)
{
    int number = int.Parse(Console.ReadLine());
    int rating = int.Parse(number.ToString()[2].ToString());
    int possibleSales = int.Parse(number.ToString().Substring(0, 2));

    if (rating == 2)
    {
        sumOfRatings += rating;
    }
    else if (rating == 3)
    {
        sumOfRatings += rating;
        numberOfSales += possibleSales * 0.50;
    }
    else if (rating == 4)
    {
        sumOfRatings += rating;
        numberOfSales += possibleSales * 0.70;
    }
    else if (rating == 5)
    {
        sumOfRatings += rating;
        numberOfSales += possibleSales * 0.85;
    }
    else if (rating == 6)
    {
        sumOfRatings += rating;
        numberOfSales += possibleSales;
    }
}

Console.WriteLine($"{numberOfSales:F2}");
Console.WriteLine($"{sumOfRatings / n:F2}");