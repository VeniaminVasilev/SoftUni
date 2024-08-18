namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listTires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires") { break; }

                string[] tokens = command.Split(" ");
                Tire[] tires = new Tire[4];

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);

                    if (i == 0)
                    {
                        tires[i] = new Tire(year, pressure);
                    }
                    else
                    {
                        tires[i / 2] = new Tire(year, pressure);
                    }
                }

                listTires.Add(tires);
            }

            List<Engine> listEngines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engines done") { break; }

                string[] tokens = command.Split(" ");
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                listEngines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> listCars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Show special") { break; }

                string[] tokens = command.Split(" ");
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, listEngines[engineIndex], listTires[tiresIndex]);

                listCars.Add(newCar);
            }

            List<Car> specialCars = new List<Car>();

            foreach (Car car in listCars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double totalTirePressure = 0;

                    foreach (Tire tire in car.Tires)
                    {
                        totalTirePressure += tire.Pressure;
                    }

                    if (totalTirePressure >= 9 && totalTirePressure <= 10)
                    {
                        car.Drive(20);

                        specialCars.Add(car);
                    }
                }
            }

            foreach (Car car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}