namespace _09.ExplicitInterfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string information = Console.ReadLine();
                if (information == "End") { break; }

                string[] data = information.Split(" ");
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}