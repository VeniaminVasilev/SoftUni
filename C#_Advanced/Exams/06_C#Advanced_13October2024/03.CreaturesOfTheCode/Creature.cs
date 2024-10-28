namespace CreaturesOfTheCode
{
    public class Creature
    {
        private string _name;
        private string _kind;
        private int _health;
        private List<string> _abilities;

        public string Name { get { return _name; } }
        public string Kind { get { return _kind; } }
        public int Health { get { return _health; } }
        public List<string> Abilities { get { return _abilities; } }

        public Creature(string name, string kind, int health, string abilities)
        {
            _name = name;
            _kind = kind;
            _health = health;
            _abilities = new List<string>(abilities.Split(", "));
        }

        public override string ToString()
        {
            return $"{_name} ({_kind}) has {_health} HP\nAbilities: {string.Join(", ", _abilities)}";
        }
    }
}