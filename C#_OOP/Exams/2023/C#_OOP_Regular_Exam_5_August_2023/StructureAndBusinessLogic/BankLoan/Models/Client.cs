using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string _name;
        private string _id;
        private int _interest;
        private double _income;

        public Client(string name, string id, int interest, double income)
        {
            this.Name = name;
            this.Id = id;
            this.Interest = interest;
            this.Income = income;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
                }
                this._name = value;
            }
        }

        public string Id
        {
            get { return this._id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
                }
                this._id = value;
            }
        }

        public int Interest
        {
            get { return this._interest; }
            protected set
            {
                this._interest = value;
            }
        }

        public double Income
        {
            get { return this._income; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);
                }
                this._income = value;
            }
        }

        public abstract void IncreaseInterest();
    }
}