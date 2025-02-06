namespace _04.PizzaCalories
{
    public class Pizza
    {
        private readonly List<Topping> _toppings;

        public Pizza(string name, Dough dough)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.Name = name;
            this.Dough = dough;

            this._toppings = new List<Topping>();
            this.Toppings = this._toppings.AsReadOnly();
        }

        public string Name { get; }

        public Dough Dough { get; }

        public IReadOnlyCollection<Topping> Toppings { get; }

        public int CountOfToppings
        {
            get { return this._toppings.Count; }
        }

        public double Calories => this.Dough.Calories + this.Toppings.Sum(t => t.Calories);

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            if (topping is null) throw new ArgumentNullException(nameof(topping));

            this._toppings.Add(topping);
        }
    }
}