using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ISoldier, IPrivate, ISpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, Dictionary<string, string> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public Dictionary<string, string> Missions
        {
            get; private set;
        }

        public void CompleteMission(string codeName)
        {
            this.Missions[codeName] = "Finished";
        }

        public override string ToString()
        {
            string output = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}\nCorps: {this.Corps}\nMissions:";

            foreach (var pair in this.Missions)
            {
                output += $"\n  Code Name: {pair.Key} State: {pair.Value}";
            }

            return output;
        }
    }
}