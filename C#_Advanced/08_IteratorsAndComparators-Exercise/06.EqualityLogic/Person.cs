namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            if (this.Age != other.Age)
            {
                return this.Age - other.Age;
            }

            return string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
        }

        public override bool Equals(object? obj)
        {
            Person other = obj as Person;

            if (other == null) return false;

            return this.Name == other.Name && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode()
                + this.Age.GetHashCode();
        }
    }
}