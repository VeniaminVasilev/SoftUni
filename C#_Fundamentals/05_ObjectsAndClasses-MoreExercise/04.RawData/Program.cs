namespace _04.RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            this.Model = model;

            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
        }
    }
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
    }

    public class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string type = Console.ReadLine();
            if (type == "fragile")
            {
                foreach (Car car in cars.Where(car => car.Cargo.CargoType == "fragile" && car.Cargo.CargoWeight < 1000))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "flamable")
            {
                foreach (Car car in cars.Where(car => car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}