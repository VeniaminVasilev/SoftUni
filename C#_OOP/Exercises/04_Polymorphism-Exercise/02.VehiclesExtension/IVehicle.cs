namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        bool Drive(double distance);
        bool Refuel(double liters);
        bool DriveEmpty(double distance)
        {
            return Drive(distance);
        }
    }
}