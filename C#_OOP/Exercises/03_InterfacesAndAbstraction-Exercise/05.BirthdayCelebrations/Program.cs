namespace _05.BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthdate> citizensPets = new List<IBirthdate>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] data = command.Split(" ");

                if (data[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                    citizensPets.Add(citizen);
                }
                else if (data[0] == "Pet")
                {
                    Pet pet = new Pet(data[1], data[2]);
                    citizensPets.Add(pet);
                }
            }

            string year = Console.ReadLine();

            for (int i = 0; i < citizensPets.Count; i++)
            {
                string birthdate = citizensPets[i].Birthdate;

                if (birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthdate);
                }
            }
        }
    }
}