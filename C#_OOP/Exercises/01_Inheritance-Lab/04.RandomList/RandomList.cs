namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            if (this.Count == 0) return null;

            int randomIndex = rnd.Next(this.Count);
            string randomString = this[randomIndex];
            this.RemoveAt(randomIndex);

            return randomString;
        }
    }
}