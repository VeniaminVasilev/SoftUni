namespace _02.VehiclesExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carTokens[1]);
            double carLitersPerKm = double.Parse(carTokens[2]);
            double carTankCapacity = double.Parse(carTokens[3]);
            IVehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckLitersPerKm = double.Parse(truckTokens[2]);
            double truckTankCapacity = double.Parse(truckTokens[3]);
            IVehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busTokens[1]);
            double busLitersPerKm = double.Parse(busTokens[2]);
            double busTankCapacity = double.Parse(busTokens[3]);
            IVehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string vehicle = tokens[1];

                if (command is "Drive")
                {
                    double distance = double.Parse(tokens[2]);

                    if (distance < 0)
                    { 
                        Console.WriteLine("Distance must not be negative");
                        continue;
                    }

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
                    else if (vehicle is "Bus")
                    {
                        if (bus.Drive(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if (command is "DriveEmpty")
                {
                    double distance = double.Parse(tokens[2]);

                    if (distance < 0)
                    {
                        Console.WriteLine("Distance must not be negative");
                        continue;
                    }

                    if (vehicle is "Bus")
                    {
                        if (bus.DriveEmpty(distance))
                        {
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                else if (command is "Refuel")
                {
                    double liters = double.Parse(tokens[2]);

                    if (liters <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }

                    if (vehicle is "Car")
                    {
                        if (car.Refuel(liters) == false)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                    else if (vehicle is "Truck")
                    {
                        if (truck.Refuel(liters) == false)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                    else if (vehicle is "Bus")
                    {
                        if (bus.Refuel(liters) == false)
                        {
                            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                        }
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}