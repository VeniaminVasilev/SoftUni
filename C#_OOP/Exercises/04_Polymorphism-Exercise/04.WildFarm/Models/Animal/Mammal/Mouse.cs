using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animal.Mammal
{
    public class Mouse : Mammal, IEat
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public bool EatFruits(int quantity)
        {
            this.Weight += quantity * 0.10;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatMeat(int quantity)
        {
            return false;
        }

        public bool EatSeeds(int quantity)
        {
            return false;
        }

        public bool EatVegetables(int quantity)
        {
            this.Weight += quantity * 0.10;
            this.FoodEaten += quantity;
            return true;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}