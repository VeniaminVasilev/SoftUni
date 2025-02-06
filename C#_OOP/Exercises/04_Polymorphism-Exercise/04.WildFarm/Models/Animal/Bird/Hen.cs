using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animal.Bird
{
    public class Hen : Bird, IEat
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public bool EatFruits(int quantity)
        {
            this.Weight += quantity * 0.35;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatVegetables(int quantity)
        {
            this.Weight += quantity * 0.35;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatMeat(int quantity)
        {
            this.Weight += quantity * 0.35;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatSeeds(int quantity)
        {
            this.Weight += quantity * 0.35;
            this.FoodEaten += quantity;
            return true;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}