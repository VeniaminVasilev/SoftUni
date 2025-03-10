using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int _interestRate;
        private double _amount;

        public Loan(int interestRate, double amount)
        {
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        public int InterestRate
        {
            get { return this._interestRate; }
            private set { this._interestRate = value; }
        }

        public double Amount
        {
            get { return this._amount; }
            private set { this._amount = value; }
        }
    }
}