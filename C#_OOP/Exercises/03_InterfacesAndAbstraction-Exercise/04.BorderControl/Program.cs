namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> inhabitants = new List<IIdentifiable>();

            while(true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] data = command.Split(" ");

                if (data.Length == 2)
                {
                    Robot robot = new Robot(data[0], data[1]);
                    inhabitants.Add(robot);
                }
                else if (data.Length == 3)
                {
                    Citizen citizen = new Citizen(data[0], int.Parse(data[1]), data[2]);
                    inhabitants.Add(citizen);
                }
            }

            string marker = Console.ReadLine();

            for (int i = 0; i < inhabitants.Count; i++)
            {
                string id = inhabitants[i].Id;

                if (id.EndsWith(marker))
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}