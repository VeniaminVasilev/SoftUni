using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _models;

        public LoanRepository()
        {
            this._models = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(ILoan model)
        {
            this._models.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return this._models.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
            return this._models.Remove(model);
        }
    }
}