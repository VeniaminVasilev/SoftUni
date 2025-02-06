namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price) { }

        public double Milliliters { get; set; }
    }
}