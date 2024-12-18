﻿namespace _02.VehiclesExtension
{
    public class Truck : IVehicle
    {
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
            this.TankCapacity = tankCapacity;
        }

        public bool Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return false;
            }
            else
            {
                this.FuelQuantity -= neededFuel;
                return true;
            }
        }

        public bool Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                return false;
            }
            else
            {
                this.FuelQuantity += liters;
                return true;
            }
        }
    }
}