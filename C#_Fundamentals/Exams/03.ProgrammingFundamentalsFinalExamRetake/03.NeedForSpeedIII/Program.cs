namespace _03.NeedForSpeedIII
{
    class Car
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|");
                string carName = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                Car car = new Car()
                {
                    Name = carName,
                    Mileage = mileage,
                    Fuel = fuel
                };
                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop") { break; }

                string[] tokens = command.Split(" : ");
                string action = tokens[0];
                string car = tokens[1];
                Car currentCar = cars.FirstOrDefault(c => c.Name.Equals(car));

                if (action == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (currentCar.Fuel < fuel)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else if (currentCar.Fuel >= fuel)
                    {
                        currentCar.Mileage += distance;
                        currentCar.Fuel -= fuel;

                        Console.WriteLine($"{currentCar.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (currentCar.Mileage >= 100000)
                    {
                        cars.Remove(currentCar);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);

                    if (currentCar.Fuel + fuel > 75)
                    {
                        int usedFuel = 75 - currentCar.Fuel;
                        currentCar.Fuel = 75;
                        Console.WriteLine($"{car} refueled with {usedFuel} liters");
                    }
                    else if (currentCar.Fuel + fuel <= 75)
                    {
                        currentCar.Fuel += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(tokens[2]);

                    if (currentCar.Mileage - kilometers < 10000)
                    {
                        currentCar.Mileage = 10000;
                    }
                    else if (currentCar.Mileage - kilometers >= 10000)
                    {
                        currentCar.Mileage -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}