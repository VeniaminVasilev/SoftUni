using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ISoldier, IPrivate, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> privatesSet) : base(id, firstName, lastName, salary)
        {
            this.PrivatesSet = privatesSet;
        }

        public List<Private> PrivatesSet { get; private set; }
        public override string ToString()
        {
            string output = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}\nPrivates:";

            for (int i = 0; i < this.PrivatesSet.Count; i++)
            {
                output += $"\n  {PrivatesSet[i].ToString()}";
            }

            return output;
        }

    }
}