using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> _models;

        public RouteRepository()
        {
            this._models = new List<IRoute>();
        }

        public void AddModel(IRoute model)
        {
            this._models.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return this._models.FirstOrDefault(m => m.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return this._models.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return this._models.Remove(this._models.FirstOrDefault(m => m.RouteId == int.Parse(identifier)));
        }
    }
}