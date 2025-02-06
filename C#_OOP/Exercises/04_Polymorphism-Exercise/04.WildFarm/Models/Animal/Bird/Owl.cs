using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animal.Bird
{
    public class Owl : Bird, IEat
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public bool EatFruits(int quantity)
        {
            return false;
        }

        public bool EatMeat(int quantity)
        {
            this.Weight += quantity * 0.25;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatSeeds(int quantity)
        {
            return false;
        }

        public bool EatVegetables(int quantity)
        {
            return false;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}