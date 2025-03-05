using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> _all;

        public ClimberRepository()
        {
            this._all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All
        {
            get { return this._all.AsReadOnly(); }
        }

        public void Add(IClimber model)
        {
            this._all.Add(model);
        }

        public IClimber Get(string name)
        {
            return this._all.FirstOrDefault(c => c.Name == name);
        }
    }
}