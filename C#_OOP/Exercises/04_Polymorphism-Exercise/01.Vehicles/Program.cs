namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(carTokens[1]);
            double litersPerKm = double.Parse(carTokens[2]);
            IVehicle car = new Car(fuelQuantity, litersPerKm);

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckLitersPerKm = double.Parse(truckTokens[2]);
            IVehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string vehicle = tokens[1];

                if (command is "Drive")
                {
                    double distance = double.Parse(tokens[2]);
                    if (vehicle is "Car")
                    {
                        if (car.Drive(distance))
                        {
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (vehicle is "Truck")
                    {
                        if (truck.Drive(distance))
                        {
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (command is "Refuel")
                {
                    double liters = double.Parse(tokens[2]);
                    if (vehicle is "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicle is "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}