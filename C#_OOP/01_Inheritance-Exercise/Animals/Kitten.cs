namespace Animals
{
    public class Kitten : Cat
    {
        private const string _gender = "Female";
        public Kitten(string name, int age) : base(name, age, _gender) { }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return "Kitten";
        }
    }
}