using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> _models;

        public PlayerRepository()
        {
            this._models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IPlayer model)
        {
            this._models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            if (this.Models.FirstOrDefault(m => m.Name == name) == null)
            {
                return false;
            }
            return true;
        }

        public IPlayer GetModel(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }

        public bool RemoveModel(string name)
        {
            IPlayer player = _models.FirstOrDefault(m => m.Name == name);

            if (player == null)
            {
                return false;
            }

            return this._models.Remove(player);
        }
    }
}