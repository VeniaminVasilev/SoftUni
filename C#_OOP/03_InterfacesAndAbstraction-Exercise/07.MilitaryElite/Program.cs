using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            List<Private> privateSoldiers = new List<Private>();

            while (true)
            {
                string information = Console.ReadLine();
                if (information == "End") { break; }

                string[] data = information.Split(" ");
                
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];

                if (data[0] == "Private")
                {
                    decimal salary = decimal.Parse(data[4]);
                    Private privateSoldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(privateSoldier);
                    privateSoldiers.Add(privateSoldier);
                }
                else if (data[0] == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(data[4]);
                    List<int> privatesIds = data
                        .Skip(5)
                        .Select(int.Parse)
                        .ToList();

                    List<Private> privatesSet = new List<Private>();

                    for (int i = 0; i < privatesIds.Count; i++)
                    {
                        Private newPrivate = privateSoldiers.FirstOrDefault(s => s.Id == privatesIds[i]);
                        privatesSet.Add(newPrivate);
                    }

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privatesSet);
                    soldiers.Add(lieutenantGeneral);
                }
                else if (data[0] == "Engineer")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    if (corps != "Airforces" && corps != "Marines") { continue; }

                    List<string> repairInfo = data
                        .Skip(6)
                        .ToList();

                    Dictionary<string, int> repairs = new Dictionary<string, int>();

                    for (int i = 0; i < repairInfo.Count; i += 2)
                    {
                        repairs.Add(repairInfo[i], int.Parse(repairInfo[i + 1]));
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    soldiers.Add(engineer);
                }
                else if (data[0] == "Commando")
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    if (corps != "Airforces" && corps != "Marines") { continue; }

                    List<string> missionInfo = data
                        .Skip(6)
                        .ToList();

                    Dictionary<string, string> missions = new Dictionary<string, string>();

                    for (int i = 0; i < missionInfo.Count; i += 2)
                    {
                        if (missionInfo[i + 1] != "InProgress" && missionInfo[i + 1] != "Finished") { continue; }

                        missions.Add(missionInfo[i], missionInfo[i + 1]);
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(commando);
                }
                else if (data[0] == "Spy")
                {
                    int codeNumber = int.Parse(data[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}