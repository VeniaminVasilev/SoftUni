namespace _05.ComparingObjects
{
    public class EqualPeopleCollection
    {
        private List<Person> equalPeople = new List<Person>();

        public int Count { get; set; }

        public EqualPeopleCollection(List<Person> peopleList, Person person)
        { 
            for (int i = 0; i < peopleList.Count; i++)
            {
                if (person.CompareTo(peopleList[i]) == 0)
                {
                    equalPeople.Add(peopleList[i]);
                }
            }
            Count = equalPeople.Count;
        }
    }
}