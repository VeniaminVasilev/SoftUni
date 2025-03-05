using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;

        public Climber(string name, int stamina)
        {
            this.Name = name;
            this.Stamina = stamina;
            this._conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public int Stamina
        {
            get { return this._stamina; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 10)
                {
                    value = 10;
                }
                this._stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks
        {
            get { return this._conqueredPeaks.AsReadOnly(); }
        }

        public void Climb(IPeak peak)
        {
            if (!_conqueredPeaks.Contains(peak.Name))
            {
                this._conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                this.Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                this.Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                this.Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {this.Name}, Stamina: {this.Stamina}");
            if (this.ConqueredPeaks.Count == 0)
            {
                sb.AppendLine("Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {ConqueredPeaks.Count}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}