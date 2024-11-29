namespace _04.WildFarm.Models.Animal.Mammal
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; private set; }

        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
    }
}