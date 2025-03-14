using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _models;

        public UserRepository()
        {
            this._models = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            this._models.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return this._models.FirstOrDefault(m => m.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return this._models.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return this._models.Remove(this._models.FirstOrDefault(m => m.DrivingLicenseNumber == identifier));
        }
    }
}