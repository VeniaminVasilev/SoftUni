using _04.WildFarm.Models.Animal;
using _04.WildFarm.Models.Animal.Bird;
using _04.WildFarm.Models.Animal.Mammal;
using _04.WildFarm.Models.Animal.Mammal.Feline;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lineNumber = 0;
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] information = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineNumber % 2 == 0)
                {
                    string type = information[0];
                    string name = information[1];
                    double weight = double.Parse(information[2]);

                    if (type == "Cat")
                    {
                        string livingRegion = information[3];
                        string breed = information[4];

                        Animal cat = new Cat(name, weight, livingRegion, breed);
                        animals.Add(cat);
                    }
                    else if (type == "Tiger")
                    {
                        string livingRegion = information[3];
                        string breed = information[4];

                        Animal tiger = new Tiger(name, weight, livingRegion, breed);
                        animals.Add(tiger);
                    }
                    else if (type == "Hen")
                    {
                        double wingSize = double.Parse(information[3]);

                        Animal hen = new Hen(name, weight, wingSize);
                        animals.Add(hen);
                    }
                    else if (type == "Owl")
                    {
                        double wingSize = double.Parse(information[3]);

                        Animal owl = new Owl(name, weight, wingSize);
                        animals.Add(owl);
                    }
                    else if (type == "Dog")
                    {
                        string livingRegion = information[3];

                        Animal dog = new Dog(name, weight, livingRegion);
                        animals.Add(dog);
                    }
                    else if (type == "Mouse")
                    {
                        string livingRegion = information[3];

                        Animal mouse = new Mouse(name, weight, livingRegion);
                        animals.Add(mouse);
                    }
                }
                else
                {
                    string foodType = information[0];
                    int foodQuantity = int.Parse(information[1]);

                    bool animalEats = true;
                    IEat animal = (IEat)animals.Last();
                    Animal animalSound = animals.Last();

                    if (foodType == "Vegetable")
                    {
                        Food food = new Vegetable(foodQuantity);

                        animalEats = animal.EatVegetables(foodQuantity);
                    }
                    else if (foodType == "Fruit")
                    {
                        Food food = new Fruit(foodQuantity);

                        animalEats = animal.EatFruits(foodQuantity);
                    }
                    else if (foodType == "Meat")
                    {
                        Food food = new Meat(foodQuantity);

                        animalEats = animal.EatMeat(foodQuantity);
                    }
                    else if (foodType == "Seeds")
                    {
                        Food food = new Seeds(foodQuantity);

                        animalEats = animal.EatSeeds(foodQuantity);
                    }

                    Console.WriteLine(animalSound.ProduceSound());

                    if (!animalEats)
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                    }
                }

                lineNumber++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}