﻿using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animal.Mammal.Feline
{
    public class Cat : Feline, IEat
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public bool EatFruits(int quantity)
        {
            return false;
        }

        public bool EatMeat(int quantity)
        {
            this.Weight += quantity * 0.30;
            this.FoodEaten += quantity;
            return true;
        }

        public bool EatSeeds(int quantity)
        {
            return false;
        }

        public bool EatVegetables(int quantity)
        {
            this.Weight += quantity * 0.30;
            this.FoodEaten += quantity;
            return true;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}