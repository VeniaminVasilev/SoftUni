using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string FirstName, string LastName)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}