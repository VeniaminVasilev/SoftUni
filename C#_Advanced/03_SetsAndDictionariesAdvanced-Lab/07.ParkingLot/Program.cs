namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") { break; }

                string[] tokens = command.Split(", ");
                string action = tokens[0];
                string licensePlate = tokens[1];

                if (action == "IN")
                {
                    parkingLot.Add(licensePlate);
                }
                else if (action == "OUT")
                {
                    parkingLot.Remove(licensePlate);
                }
            }

            if (parkingLot.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}