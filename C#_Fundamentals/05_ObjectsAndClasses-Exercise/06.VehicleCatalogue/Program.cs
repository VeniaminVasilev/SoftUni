namespace _06.VehicleCatalogue
{
    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Car(string model, string color, int horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }

    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set;}

        public Truck(string model, string color, int horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End") { break; }

                string[] tokens = command.Split(" ");
                string typeOfVehicle = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                if (typeOfVehicle == "car")
                {
                    Car car = new Car(model, color, horsePower);
                    cars.Add(car);
                }
                else if (typeOfVehicle == "truck")
                {
                    Truck truck = new Truck(model, color, horsePower);
                    trucks.Add(truck);
                }
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue") { break; };

                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model == model)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine($"Model: {cars[i].Model}");
                        Console.WriteLine($"Color: {cars[i].Color}");
                        Console.WriteLine($"Horsepower: {cars[i].HorsePower}");
                        break;
                    }
                }

                for (int i = 0; i < trucks.Count; i++)
                {
                    if (trucks[i].Model == model)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {trucks[i].Model}");
                        Console.WriteLine($"Color: {trucks[i].Color}");
                        Console.WriteLine($"Horsepower: {trucks[i].HorsePower}");
                        break;
                    }
                }
            }

            double carsAverageHorsePower = 0;
            double trucksAverageHorsePower = 0;

            if (cars.Count > 0)
            {
                carsAverageHorsePower = cars.Average(car => car.HorsePower);
            }
            
            if (trucks.Count > 0)
            {
                trucksAverageHorsePower = trucks.Average(truck => truck.HorsePower);
            }

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower:F2}.");
        }
    }
}