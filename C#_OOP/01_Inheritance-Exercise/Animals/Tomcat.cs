namespace Animals
{
    public class Tomcat : Cat
    {
        private const string _gender = "Male";
        public Tomcat(string name, int age) : base(name, age, _gender) { }

        public override string ProduceSound()
        {
            return "MEOW";
        }

        public override string ToString()
        {
            return "Tomcat";
        }
    }
}