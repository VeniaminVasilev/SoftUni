using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> _models;
        private int _capacity = 10;

        public TeamRepository()
        {
            this._models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models
        {
            get { return this._models.AsReadOnly(); }
            private set { this._models = (List<ITeam>)value; }
        }

        public int Capacity
        {
            get { return this._capacity; }
        }

        public void Add(ITeam model)
        {
            if (this._models.Count < this.Capacity)
            {
                this._models.Add(model);
            }
        }

        public bool Exists(string name)
        {
            return this._models.Any(t => t.Name == name);
        }

        public ITeam Get(string name)
        {
            ITeam team = _models.Where(t => t.Name == name).FirstOrDefault();

            if (team == null)
            {
                return null;
            }
            return team;
        }

        public bool Remove(string name)
        {
            ITeam team = _models.Where(t => t.Name == name).FirstOrDefault();

            if (team == null)
            {
                return false;
            }
            else
            {
                _models.Remove(team);
                return true;
            }
        }
    }
}