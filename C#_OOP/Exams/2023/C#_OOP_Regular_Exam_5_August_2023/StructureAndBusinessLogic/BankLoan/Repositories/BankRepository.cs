using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _models;

        public BankRepository()
        {
            this._models = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IBank model)
        {
            this._models.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }

        public bool RemoveModel(IBank model)
        {
            return this._models.Remove(model);
        }
    }
}