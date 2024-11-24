using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISoldier, IPrivate, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get;
            private set;
        }
    }
}