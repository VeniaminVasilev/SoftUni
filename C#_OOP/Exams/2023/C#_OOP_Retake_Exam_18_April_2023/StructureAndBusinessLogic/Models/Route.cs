using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string _startPoint;
        private string _endPoint;
        private double _length;
        private int _routeId;
        private bool _isLocked;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
            this._isLocked = false;
        }

        public string StartPoint
        {
            get { return this._startPoint; }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                this._startPoint = value;
            }
        }

        public string EndPoint
        {
            get { return this._endPoint; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                this._endPoint = value;
            }
        }

        public double Length
        {
            get { return this._length; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                this._length = value;
            }
        }

        public int RouteId
        {
            get { return this._routeId; }
            private set { this._routeId = value; }
        }

        public bool IsLocked
        {
            get { return this._isLocked; }
            private set { this._isLocked = value; }
        }

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}