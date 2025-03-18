using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> _models;

        public RobotRepository()
        {
            this._models = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            this._models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return this._models.FirstOrDefault(m => m.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return this._models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            return this._models.Remove(this._models.FirstOrDefault(m => m.Model == typeName));
        }
    }
}