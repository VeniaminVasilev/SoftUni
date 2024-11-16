namespace _04.PizzaCalories
{
    public class Topping
    {
        public Topping(string type, int weight)
        {
            string[] correctTypes = { "meat", "veggies", "cheese", "sauce" };
            string formattedType = type.ToLower();
            bool typeIsCorrect = correctTypes.Contains(formattedType);

            if (!typeIsCorrect)
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            if (weight < 1 || weight > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }

            this.Type = type;
            this.Weight = weight;
        }

        public string Type { get; }

        public int Weight { get; }

        public double Calories
        {
            get
            {
                double modifier = 0;

                string formattedType = this.Type.ToLower();
                switch(formattedType)
                {
                    case "meat":
                        modifier = 1.2;
                        break;
                    case "veggies":
                        modifier = 0.8;
                        break;
                    case "cheese":
                        modifier = 1.1;
                        break;
                    case "sauce":
                        modifier = 0.9;
                        break;
                }

                return (this.Weight * 2) * modifier;
            }
        }
    }
}