using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string _name;
        private int _capacity;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        public Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this._loans = new List<ILoan>();
            this._clients = new List<IClient>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public int Capacity
        {
            get { return this._capacity; }
            private set { this._capacity = value; }
        }

        public IReadOnlyCollection<ILoan> Loans
        {
            get { return this._loans.AsReadOnly(); }
        }

        public IReadOnlyCollection<IClient> Clients
        {
            get { return this._clients.AsReadOnly(); }
        }

        public void AddClient(IClient Client)
        {
            if (this.Capacity <= this._clients.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            this._clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
        {
            this._loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            List<string> clientNames = new List<string>();
            foreach (IClient client in Clients)
            {
                clientNames.Add(client.Name);
            }

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");

            if (clientNames.Count == 0)
            {
                sb.AppendLine($"Clients: none");
            }
            else
            {
                sb.AppendLine($"Clients: {string.Join(", ", clientNames)}");
            }

            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            this._clients.Remove(Client);
        }

        public double SumRates()
        {
            double sum = _loans.Sum(l => l.InterestRate);
            return sum;
        }
    }
}