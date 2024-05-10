namespace _03.SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKilometer { get; set; }
        public decimal TraveledDistance { get; set; }

        public Car(string model, decimal fuelAmount, decimal fuelCosumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelCosumptionPerKilometer;
            this.TraveledDistance = 0;
        }

        public void AttemptToDrive(decimal amountOfKm)
        {
            if ((amountOfKm * FuelConsumptionPerKilometer) <= FuelAmount)
            {
                FuelAmount -= amountOfKm * FuelConsumptionPerKilometer;
                TraveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
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
                decimal fuelAmount = decimal.Parse(tokens[1]);
                decimal fuelConsumptionPerKilometer = decimal.Parse(tokens[2]);

                Car car = new Car (model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] tokens = command.Split(" ");
                string model = tokens[1];
                decimal amountOfKm = decimal.Parse(tokens[2]);

                cars.Find(c => c.Model == model).AttemptToDrive(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}