using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;

namespace CyberSecurityDS.Models
{
    public abstract class DefensiveSoftware : IDefensiveSoftware
    {
        private string _name;
        private int _effectiveness;
        private List<string> _assignedAttacks;

        public DefensiveSoftware(string name, int effectiveness)
        {
            Name = name;
            Effectiveness = effectiveness;
            AssignedAttacks = new List<string>();
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.SoftwareNameRequired);
                }

                _name = value;
            }
        }

        public int Effectiveness
        {
            get { return _effectiveness; }
            private set
            {
                if (value >= 1 & value <= 10)
                {
                    _effectiveness = value;
                }
                else if (value == 0)
                {
                    _effectiveness = 1;
                }
                else if (value > 10)
                {
                    _effectiveness = 10;
                }
                else if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.EffectivenessNegative);
                }
            }
        }

        public IReadOnlyCollection<string> AssignedAttacks
        {
            get { return _assignedAttacks.AsReadOnly(); }
            private set { _assignedAttacks = new List<string>(); }
        }

        public void AssignAttack(string attackName)
        {
            _assignedAttacks.Add(attackName);
        }

        public override string ToString()
        {
            if (_assignedAttacks.Count == 0)
            {
                return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: [None]";
            }
            else
            {
                return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: {string.Join(", ", _assignedAttacks)}";
            }
        }
    }
}