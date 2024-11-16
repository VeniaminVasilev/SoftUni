namespace _04.PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ");
                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split(" ");
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                int doughWeight = int.Parse(doughInfo[3]);
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "END") { break; }

                    string[] toppingInfo = command.Split(" ");
                    string type = toppingInfo[1];
                    int toppingWeight = int.Parse(toppingInfo[2]);
                    Topping topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}