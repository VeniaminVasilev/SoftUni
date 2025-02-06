namespace _04.WildFarm.Models.Food
{
    public abstract class Food
    {
        public int Quantity { get; private set; }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}