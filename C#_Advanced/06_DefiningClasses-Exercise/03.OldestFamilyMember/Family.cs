namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = null;

            foreach (Person person in this.People)
            {
                if (oldestPerson == null || person.Age > oldestPerson.Age)
                {
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }
    }
}