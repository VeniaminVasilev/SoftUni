using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string _name;
        private double _points;
        private int _timeToCatch;

        public Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                this._name = value;
            }
        }

        public double Points
        {
            get { return this._points; }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }

                this._points = value;
            }
        }

        public int TimeToCatch
        {
            get { return this._timeToCatch; }
            private set { this._timeToCatch = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name} [ Points: {this.Points}, Time to Catch: {this.TimeToCatch} seconds ]";
        }
    }
}