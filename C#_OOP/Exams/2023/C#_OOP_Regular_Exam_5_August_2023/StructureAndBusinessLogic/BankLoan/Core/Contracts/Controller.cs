using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BankLoan.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<ILoan> _loans;
        private IRepository<IBank> _banks;

        public Controller() 
        {
            this._loans = new LoanRepository();
            this._banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank;
            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
                _banks.AddModel(bank);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
                _banks.AddModel(bank);
            }

            return String.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != nameof(Student) && clientTypeName != nameof(Adult))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = _banks.FirstModel(bankName);

            if (bank.GetType().Name == "BranchBank" && clientTypeName != "Student" || bank.GetType().Name == "CentralBank" && clientTypeName != "Adult")
            {
                return String.Format(OutputMessages.UnsuitableBank);
            }

            IClient client;
            if (bank.GetType().Name == "BranchBank")
            {
                client = new Student(clientName, id, income);
                bank.AddClient(client);
            }
            else if (bank.GetType().Name == "CentralBank")
            {
                client = new Adult(clientName, id, income);
                bank.AddClient(client);
            }

            return String.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != nameof(StudentLoan) && loanTypeName != nameof(MortgageLoan))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan;
            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
                this._loans.AddModel(loan);
            }
            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
                this._loans.AddModel(loan);
            }
            return String.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = _banks.FirstModel(bankName);

            double funds = bank.Clients.Sum(c => c.Income);
            funds += bank.Loans.Sum(l => l.Amount);

            return $"The funds of bank {bankName} are {funds:F2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            if (this._loans.FirstModel(loanTypeName) == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }
            ILoan loan = this._loans.FirstModel(loanTypeName);
            IBank bank = this._banks.FirstModel(bankName);

            bank.AddLoan(loan);
            this._loans.RemoveModel(loan);

            return String.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IBank bank in _banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}