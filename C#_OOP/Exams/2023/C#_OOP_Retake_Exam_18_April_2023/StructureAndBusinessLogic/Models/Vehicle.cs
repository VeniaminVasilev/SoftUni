using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.ComponentModel.Design;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string _brand;
        private string _model;
        private double _maxMileage;
        private string _licensePlateNumber;
        private int _batteryLevel;
        private bool _isDamaged;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
            this._batteryLevel = 100;
            this._isDamaged = false;
        }

        public string Brand
        {
            get { return this._brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                this._brand = value;
            }
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                this._model = value;
            }
        }

        public double MaxMileage
        {
            get { return this._maxMileage; }
            private set { this._maxMileage = value; }
        }

        public string LicensePlateNumber
        {
            get { return this._licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                this._licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get { return this._batteryLevel; }
            private set { this._batteryLevel = value; }
        }

        public bool IsDamaged
        {
            get { return this._isDamaged; }
            private set { this._isDamaged = value; }
        }

        public void ChangeStatus()
        {
            if (this.IsDamaged == false) { this.IsDamaged = true; }
            else if (this.IsDamaged == true) { this.IsDamaged = false; }
        }

        public void Drive(double mileage)
        {
            int percentage = (int)Math.Round(mileage * 100 / this.MaxMileage);
            this.BatteryLevel -= percentage;

            if (this.GetType().Name == "CargoVan")
            {
                this.BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public override string ToString()
        {
            string status;
            if (this.IsDamaged)
            {
                status = "damaged";
            }
            else
            {
                status = "OK";
            }
            return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: {status}";
        }
    }
}