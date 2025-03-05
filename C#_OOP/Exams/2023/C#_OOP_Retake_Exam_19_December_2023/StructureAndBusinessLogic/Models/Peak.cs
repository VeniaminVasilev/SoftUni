using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string _name;
        private int _elevation;
        private string _difficultyLevel;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            this.Name = name;
            this.Elevation = elevation;
            this.DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public int Elevation
        {
            get { return this._elevation; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }
                this._elevation = value;
            }
        }

        public string DifficultyLevel
        {
            get { return this._difficultyLevel; }
            private set { this._difficultyLevel = value; }
        }

        public override string ToString()
        {
            return $"Peak: {this.Name} -> Elevation: {this.Elevation}, Difficulty: {this.DifficultyLevel}";
        }
    }
}