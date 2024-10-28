using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Beast!") { break; }

                try
                {
                    if (command == "Dog")
                    {
                        string[] information = Console.ReadLine().Split(' ');
                        string name = information[0];
                        int age = int.Parse(information[1]);
                        string gender = information[2];

                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (command == "Frog")
                    {
                        string[] information = Console.ReadLine().Split(' ');
                        string name = information[0];
                        int age = int.Parse(information[1]);
                        string gender = information[2];

                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (command == "Cat")
                    {
                        string[] information = Console.ReadLine().Split(' ');
                        string name = information[0];
                        int age = int.Parse(information[1]);
                        string gender = information[2];

                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (command == "Kitten")
                    {
                        string[] information = Console.ReadLine().Split(' ');
                        string name = information[0];
                        int age = int.Parse(information[1]);

                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (command == "Tomcat")
                    {
                        string[] information = Console.ReadLine().Split(' ');
                        string name = information[0];
                        int age = int.Parse(information[1]);

                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i]);
                Console.WriteLine($"{animals[i].Name} {animals[i].Age} {animals[i].Gender}");
                Console.WriteLine(animals[i].ProduceSound());
            }
        }
    }
}