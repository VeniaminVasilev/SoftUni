using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models
{
    public class Dealership : IDealership
    {
        public Dealership()
        {
            Vehicles = new VehicleRepository();
            Customers = new CustomerRepository();
        }

        public IRepository<IVehicle> Vehicles { get; }
        public IRepository<ICustomer> Customers { get; }
    }
}