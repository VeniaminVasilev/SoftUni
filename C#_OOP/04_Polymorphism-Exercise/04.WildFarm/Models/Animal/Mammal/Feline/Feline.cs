namespace _04.WildFarm.Models.Animal.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }

        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
    }
}