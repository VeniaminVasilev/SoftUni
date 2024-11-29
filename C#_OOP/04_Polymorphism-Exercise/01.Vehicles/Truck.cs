namespace _01.Vehicles
{
    public class Truck : IVehicle
    {
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
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

        public void Refuel(double liters)
        {
            this.FuelQuantity += (liters * 0.95);
        }
    }
}