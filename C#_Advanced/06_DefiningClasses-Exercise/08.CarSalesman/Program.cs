namespace _08.CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = information[0];
                int power = int.Parse(information[1]);
                int? displacement = null;
                string efficiency = null;

                if (information.Length > 2)
                {
                    if (int.TryParse(information[2], out int disp))
                    {
                        displacement = disp;
                    }
                    else
                    {
                        efficiency = information[2];
                    }
                }

                if (information.Length > 3)
                {
                    efficiency = information[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int c = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < c; i++)
            {
                string[] information = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = information[0];
                string engineModel = information[1];
                int? weight = null;
                string color = null;

                if (information.Length > 2)
                {
                    if (int.TryParse(information[2], out int w))
                    {
                        weight = w;
                    }
                    else
                    {
                        color = information[2];
                    }
                }

                if (information.Length > 3)
                {
                    color = information[3];
                }

                Engine currentEngine = engines.Where(e => e.Model == engineModel).FirstOrDefault();

                Car newCar = new Car(carModel, currentEngine, weight, color);
                cars.Add(newCar);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement == null)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight == null)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }

                if (car.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}