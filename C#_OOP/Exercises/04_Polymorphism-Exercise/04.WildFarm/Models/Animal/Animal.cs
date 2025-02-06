namespace _04.WildFarm.Models.Animal
{
    public abstract class Animal
    {
        public string Name { get; private set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public abstract string ProduceSound();
    }
}