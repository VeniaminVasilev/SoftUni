using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private List<IGuild> _models;

        public GuildRepository()
        {
            this._models = new List<IGuild>();
        }

        public void AddModel(IGuild entity)
        {
            this._models.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return this._models.AsReadOnly();
        }

        public IGuild GetModel(string runeMarkOrGuildName)
        {
            return this._models.FirstOrDefault(m => m.Name == runeMarkOrGuildName);
        }
    }
}