namespace _04.PizzaCalories
{
    public class Dough
    {
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            string formattedFlourType = flourType.ToLower();
            string formattedBakingTechnique = bakingTechnique.ToLower();

            if (formattedFlourType != "white" && formattedFlourType != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (formattedBakingTechnique != "crispy" && formattedBakingTechnique != "chewy" 
                && formattedBakingTechnique != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (weight < 1 || weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range[1..200].");
            }

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType { get; }

        public string BakingTechnique { get; }

        public double Weight { get; }

        public double Calories
        {
            get
            {
                double flourTypeModifier = 1;
                double bakingTechniqueModifier = 1;

                string formattedFlourType = this.FlourType.ToLower();
                switch(formattedFlourType)
                {
                    case "white":
                        flourTypeModifier *= 1.5;
                        break;
                    case "wholegrain":
                        flourTypeModifier *= 1.0;
                        break;
                }

                string formattedBakingTechnique = this.BakingTechnique.ToLower();
                switch (formattedBakingTechnique)
                {
                    case "crispy":
                        bakingTechniqueModifier *= 0.9;
                        break;
                    case "chewy":
                        bakingTechniqueModifier *= 1.1;
                        break;
                    case "homemade":
                        bakingTechniqueModifier *= 1.0;
                        break;
                }

                return (2 * this.Weight) * flourTypeModifier * bakingTechniqueModifier;
            }
        }
    }
}