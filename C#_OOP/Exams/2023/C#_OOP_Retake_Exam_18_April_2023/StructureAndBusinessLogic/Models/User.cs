using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string _firstName;
        private string _lastName;
        private string _drivingLicenseNumber;
        private double _rating;
        private bool _isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this._rating = 0;
            this._isBlocked = false;
        }

        public string FirstName
        {
            get { return this._firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                this._lastName = value;
            }
        }

        public double Rating
        {
            get { return this._rating; }
            private set { this._rating = value; }
        }

        public string DrivingLicenseNumber
        {
            get { return this._drivingLicenseNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                this._drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get { return this._isBlocked; }
            private set { this._isBlocked = value; }
        }

        public void DecreaseRating()
        {
            this._rating -= 2.0;

            if (this._rating < 0)
            {
                this._rating = 0;
                this._isBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this._rating += 0.5;

            if (this._rating > 10.0)
            {
                this._rating = 10.0;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";
        }
    }
}