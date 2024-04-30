namespace _07.VehicleCatalogue
{
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; } 
        public int HorsePower { get; set; }
    }

    public class CatalogueVehicle
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end") { break; }

                string[] tokens = command.Split("/");

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                int horsePowerOrWeight = int.Parse(tokens[3]);

                if (type == "Car")
                {
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePowerOrWeight;

                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = horsePowerOrWeight;

                    trucks.Add(truck);
                }
            }

            CatalogueVehicle catalogueVehicle = new CatalogueVehicle();
            catalogueVehicle.Trucks = trucks.OrderBy(x => x.Brand).ToList();
            catalogueVehicle.Cars = cars.OrderBy(x => x.Brand).ToList();

            if (catalogueVehicle.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                for (int i = 0; i < catalogueVehicle.Cars.Count; i++)
                {
                    Console.WriteLine($"{catalogueVehicle.Cars[i].Brand}: {catalogueVehicle.Cars[i].Model} - {catalogueVehicle.Cars[i].HorsePower}hp");
                }
            }

            if (catalogueVehicle.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                for (int i = 0; i < catalogueVehicle.Trucks.Count; i++)
                {
                    Console.WriteLine($"{catalogueVehicle.Trucks[i].Brand}: {catalogueVehicle.Trucks[i].Model} - {catalogueVehicle.Trucks[i].Weight}kg");
                }
            }
        }
    }
}