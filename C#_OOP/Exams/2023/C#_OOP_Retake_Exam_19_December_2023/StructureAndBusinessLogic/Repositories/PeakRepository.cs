using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> _all;

        public PeakRepository()
        {
            this._all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All
        {
            get { return this._all.AsReadOnly(); }
        }

        public void Add(IPeak model)
        {
            this._all.Add(model);
        }

        public IPeak Get(string name)
        {
            return _all.FirstOrDefault(p => p.Name == name);
        }
    }
}