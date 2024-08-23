namespace _06.SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split(" ");
                string model = information[0];
                double fuelAmount = double.Parse(information[1]);
                double fuelConsumption = double.Parse(information[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] information = command.Split(" ");
                string carModel = information[1];
                double amountOfKm = double.Parse(information[2]);

                Car currentCar = cars.FirstOrDefault(x => x.Model == carModel);
                currentCar.Drive(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}