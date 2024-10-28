namespace CreaturesOfTheCode
{
    public class MythicalCreaturesHub
    {
        private List<Creature> _creatures;
        private int _capacity;

        public List<Creature> Creatures { get { return _creatures; } }
        public int Capacity { get { return _capacity; } }

        public MythicalCreaturesHub(int capacity)
        {
            _capacity = capacity;
            _creatures = new List<Creature>();
        }

        public void AddCreature(Creature creature)
        {
            bool creatureExists = _creatures.Any(c => string.Equals(c.Name, creature.Name, StringComparison.OrdinalIgnoreCase));

            if (_creatures.Count < _capacity && !creatureExists)
            {
                _creatures.Add(creature);
            }
        }

        public bool RemoveCreature(string name)
        {
            if (_creatures.Any(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                Creature creatureToBeRemoved = _creatures.Find(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                _creatures.Remove(creatureToBeRemoved);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Creature GetStrongestCreature()
        {
            Creature strongest = _creatures.OrderByDescending(c => c.Health).FirstOrDefault();
            return strongest;
        }

        public string Details(string creatureName)
        {
            if (_creatures.Any(c => string.Equals(c.Name, creatureName, StringComparison.OrdinalIgnoreCase)))
            {
                Creature creature = _creatures.Find(c => string.Equals(c.Name, creatureName, StringComparison.OrdinalIgnoreCase));
                return creature.ToString();
            }
            else
            {
                return $"Creature with the name {creatureName} not found.";
            }
        }

        public string GetAllCreatures()
        {
            string creatures = "Mythical Creatures:";

            List<Creature> orderedList = _creatures.OrderBy(c => c.Name).ToList();

            for (int i = 0; i < orderedList.Count; i++)
            {
                creatures += $"\n{orderedList[i].Name} -> {orderedList[i].Kind}";
            }

            return creatures;
        }
    }
}