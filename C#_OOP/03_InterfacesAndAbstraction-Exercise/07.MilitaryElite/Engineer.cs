using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, ISoldier, IPrivate, ISpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, Dictionary<string, int> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public Dictionary<string, int> Repairs { get; private set; }

        public override string ToString()
        {
            string output = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}\nCorps: {this.Corps}\nRepairs:";

            foreach (var pair in this.Repairs)
            {
                output += $"\n  Part Name: {pair.Key} Hours Worked: {pair.Value}";
            }

            return output;
        }
    }
}