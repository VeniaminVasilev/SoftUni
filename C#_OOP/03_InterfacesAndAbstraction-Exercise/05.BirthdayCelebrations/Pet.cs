namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}