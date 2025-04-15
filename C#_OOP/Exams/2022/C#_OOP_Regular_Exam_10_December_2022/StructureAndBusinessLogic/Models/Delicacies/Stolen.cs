namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double price = 3.50;

        public Stolen(string name) : base(name, price)
        {
        }
    }
}