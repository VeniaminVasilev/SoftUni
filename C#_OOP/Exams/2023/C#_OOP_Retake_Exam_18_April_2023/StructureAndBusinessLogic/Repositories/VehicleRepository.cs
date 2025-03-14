using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> _models;

        public VehicleRepository()
        {
            this._models = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            this._models.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return this._models.FirstOrDefault(m => m.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this._models.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return this._models.Remove(this._models.FirstOrDefault(m => m.LicensePlateNumber == identifier));
        }
    }
}