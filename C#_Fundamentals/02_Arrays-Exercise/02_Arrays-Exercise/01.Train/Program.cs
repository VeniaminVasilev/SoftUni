int wagons = int.Parse(Console.ReadLine());

int[] train = new int[wagons];
int allPassengers = 0;

for (int i = 0; i < wagons; i++)
{
    int passengersForCurrentWagon = int.Parse(Console.ReadLine());
    train[i] = passengersForCurrentWagon;
    allPassengers += passengersForCurrentWagon;
}

Console.WriteLine(string.Join(" ", train));
Console.WriteLine(allPassengers);