namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            bool endOfReading = false;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "PARTY")
                {
                    while (true)
                    {
                        string newCommand = Console.ReadLine();
                        if (newCommand == "END")
                        {
                            endOfReading = true;
                            break;
                        }

                        if (char.IsDigit(newCommand[0]))
                        {
                            vipGuests.Remove(newCommand);
                        }
                        else
                        {
                            guests.Remove(newCommand);
                        }
                    }
                }
                else if (command == "END")
                {
                    endOfReading = true;
                    break;
                }

                if (endOfReading) { break; }

                if (char.IsDigit(command[0]) && command.Length == 8)
                {
                    vipGuests.Add(command);
                }
                else if (char.IsLetter(command[0]) && command.Length == 8)
                {
                    guests.Add(command);
                }
            }

            Console.WriteLine(vipGuests.Count + guests.Count);
            foreach (string vip in vipGuests)
            {
                Console.WriteLine(vip);
            }
            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}