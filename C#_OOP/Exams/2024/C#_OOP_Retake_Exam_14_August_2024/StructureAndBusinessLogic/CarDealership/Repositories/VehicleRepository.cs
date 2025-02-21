using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> _models;

        public VehicleRepository()
        {
            this._models = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models { get { return _models.AsReadOnly(); } }

        public void Add(IVehicle model)
        {
            this._models.Add(model);
        }

        public bool Exists(string text)
        {
            return _models.Any(m => m.Model == text);
        }

        public IVehicle Get(string text)
        {
            IVehicle vehicle = _models.FirstOrDefault(m => m.Model == text);

            if (vehicle != null)
            {
                return vehicle;
            }
            return null;
        }

        public bool Remove(string text)
        {
            IVehicle vehicleToBeRemoved = _models.FirstOrDefault(m => m.Model == text);

            if (vehicleToBeRemoved != null)
            {
                _models.Remove(vehicleToBeRemoved);
                return true;
            }
            return false;
        }
    }
}