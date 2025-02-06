using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animal.Mammal
{
    public class Dog : Mammal, IEat
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public bool EatFruits(int quantity)
        {
            return false;
        }

        public bool EatMeat(int quantity)
        {
            this.Weight += quantity * 0.40;
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
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}