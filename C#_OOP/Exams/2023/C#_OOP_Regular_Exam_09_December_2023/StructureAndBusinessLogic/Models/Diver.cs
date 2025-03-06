using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private List<string> _catch;
        private double _competitionPoints;
        private bool _hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this._catch = new List<string>();
            this._competitionPoints = 0;
            this._hasHealthIssues = false;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this._name = value;
            }
        }

        public int OxygenLevel
        {
            get { return this._oxygenLevel; }
            protected set
            {
                if (value < 0) { value = 0; }

                this._oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get { return this._catch.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get
            {
                double roundedValue = Math.Round(this._competitionPoints, 1);
                return roundedValue;
            }
            private set
            {
                this._competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get { return this._hasHealthIssues; }
            private set { this._hasHealthIssues = value; }
        }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this._catch.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (this.HasHealthIssues == true)
            {
                HasHealthIssues = false;
            }
            else
            {
                HasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {this.CompetitionPoints} ]";
        }
    }
}