namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        public string Name { get; }
        public int Power { get; protected set; }

        protected BaseHero(string name)
        {
            this.Name = name;
        }

        public abstract string CastAbility();
    }
}