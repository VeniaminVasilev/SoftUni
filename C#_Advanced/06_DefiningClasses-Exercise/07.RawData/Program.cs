namespace _07.RawData
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
                int engineSpeed = int.Parse(information[1]);
                int enginePower = int.Parse(information[2]);
                int cargoWeight = int.Parse(information[3]);
                string cargoType = information[4];
                double tire1Pressure = double.Parse(information[5]);
                int tire1Age = int.Parse(information[6]);
                double tire2Pressure = double.Parse(information[7]);
                int tire2Age = int.Parse(information[8]);
                double tire3Pressure = double.Parse(information[9]);
                int tire3Age = int.Parse(information[10]);
                double tire4Pressure = double.Parse(information[11]);
                int tire4Age = int.Parse(information[12]);

                Engine newEngine = new Engine(engineSpeed, enginePower);
                Cargo newCargo = new Cargo(cargoType, cargoWeight);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);
                List<Tire> tires = new List<Tire>() { tire1, tire2, tire3, tire4 };

                Car newCar = new Car(model, newEngine, newCargo, tires);
                cars.Add(newCar);
            }

            List<Car> sortedCars = new List<Car>();

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.Type == "fragile")
                    {
                        foreach (Tire tire in car.Tires)
                        {
                            if (tire.Pressure < 1)
                            {
                                sortedCars.Add(car);
                                break;
                            }
                        }
                    }
                }
            }
            else if (command == "flammable")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        sortedCars.Add(car);
                    }
                }
            }

            foreach (Car car in sortedCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}