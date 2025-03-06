using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _models;

        public TeamRepository()
        {
            this._models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(ITeam model)
        {
            this._models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            if (this._models.FirstOrDefault(m => m.Name == name) == null)
            {
                return false;
            }
            return true;
        }

        public ITeam GetModel(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }

        public bool RemoveModel(string name)
        {
            ITeam team = _models.FirstOrDefault(m => m.Name == name);

            if (team == null)
            {
                return false;
            }

            return this._models.Remove(team);
        }
    }
}