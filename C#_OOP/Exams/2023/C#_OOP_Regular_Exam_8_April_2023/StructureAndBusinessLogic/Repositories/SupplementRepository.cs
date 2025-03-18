using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> _models;

        public SupplementRepository()
        {
            this._models = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            this._models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return this._models.FirstOrDefault(m => m.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return this._models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            return this._models.Remove(this._models.FirstOrDefault(m => m.GetType().Name == typeName));
        }
    }
}