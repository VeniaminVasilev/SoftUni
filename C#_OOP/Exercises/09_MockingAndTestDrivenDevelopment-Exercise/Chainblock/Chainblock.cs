using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> _transactions;

        public Chainblock()
        {
            this._transactions = new List<ITransaction>();
        }

        public int Count { get { return this._transactions.Count; } }

        public void Add(ITransaction tx)
        {
            if (!Contains(tx.Id))
            {
                this._transactions.Add(tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this._transactions.FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException("Transaction with the given ID does not exist.");
            }

            transaction.Status = newStatus;
        }

        public bool Contains(int id)
        {
            if (_transactions.Any(t => t.Id == id)) return true;
            return false;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return _transactions
                .Where(tx => tx.Amount >= lo && tx.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return _transactions.OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = this._transactions
                .Where(tx => tx.Status == status)
                .OrderByDescending(tx => tx.Amount)
                .Select(tx => tx.To);

            if (!receivers.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given status.");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this._transactions
                .Where(tx => tx.Status == status)
                .OrderByDescending(tx => tx.Amount)
                .Select(tx => tx.From);

            if (!senders.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given status.");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = _transactions.FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction with the given ID does not exist.");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> transactions = _transactions
                .Where(tx => tx.To == receiver)
                .Where(tx => tx.Amount >= lo && tx.Amount <= hi)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);

            if (!transactions.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given receiver.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactions = _transactions
                .Where(tx => tx.To == receiver)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);

            if (!transactions.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given receiver.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> transactions = _transactions
                .Where(tx => tx.From == sender)
                .Where(tx => tx.Amount > amount)
                .OrderByDescending(tx => tx.Amount);

            if (!transactions.Any())
            {
                throw new InvalidOperationException("There are no transactions satisfying the given filter.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactions = _transactions
                .Where(tx => tx.From == sender)
                .OrderByDescending(tx => tx.Amount);

            if (!transactions.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given sender.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = _transactions
                .Where(tx => tx.Status == status)
                .OrderByDescending(tx => tx.Amount);

            if (!transactions.Any())
            {
                throw new InvalidOperationException("There are no transactions with the given status.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return _transactions
                .Where(tx => tx.Status == status)
                .Where(tx => tx.Amount <= amount)
                .OrderByDescending(tx => tx.Amount);
        }

        public void RemoveTransactionById(int id)
        {
            if (!_transactions.Any(tx => tx.Id == id))
            {
                throw new InvalidOperationException("Transaction with the given ID does not exist.");
            }

            ITransaction transactionForRemoving = _transactions.FirstOrDefault(tx => tx.Id == id);
            _transactions.Remove(transactionForRemoving);
        }
    }
}