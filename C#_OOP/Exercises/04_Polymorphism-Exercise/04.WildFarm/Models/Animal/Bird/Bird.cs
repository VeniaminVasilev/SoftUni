namespace _04.WildFarm.Models.Animal.Bird
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; private set; }

        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }
    }
}