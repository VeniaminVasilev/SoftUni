using Chainblock.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private Mock<ITransaction> mockTransaction;
        private Chainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            mockTransaction = new Mock<ITransaction>();

            mockTransaction.SetupProperty(t => t.Id, 1);
            mockTransaction.SetupProperty(t => t.Status, TransactionStatus.Successfull);
            mockTransaction.SetupProperty(t => t.From, "From");
            mockTransaction.SetupProperty(t => t.To, "To");
            mockTransaction.SetupProperty(t => t.Amount, 100);

            chainblock = new Chainblock();
        }

        [Test]
        public void Add_ShouldBeSuccessful_WhenIdIsUnique()
        {
            // Act
            chainblock.Add(mockTransaction.Object);

            // Assert
            Assert.That(chainblock.Count, Is.EqualTo(1));
            Assert.That(chainblock.Contains(1));
        }

        [Test]
        public void Add_ShouldNotIncreaseCount_WhenAddingSameTransactionTwice()
        {
            // Act
            chainblock.Add(mockTransaction.Object);
            chainblock.Add(mockTransaction.Object);

            // Assert
            Assert.That(chainblock.Count, Is.EqualTo(1));
            Assert.That(chainblock.Contains(1));
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenTransactionWithGivenIdExists()
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            // Act
            bool exists = chainblock.Contains(1);

            // Assert
            Assert.That(exists, Is.True);
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenTransactionWithGivenIdDoesNotExist()
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            // Act
            bool exists = chainblock.Contains(100);

            // Assert
            Assert.That(exists, Is.False);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Count_ShouldReturnCorrectNumberOfTransactions(int n)
        {
            // Arrange
            for (int i = 0; i < n; i++)
            {
                mockTransaction = new Mock<ITransaction>();
                mockTransaction.Setup(t => t.Id).Returns(i + 1);
                mockTransaction.Setup(t => t.Status).Returns(TransactionStatus.Successfull);
                mockTransaction.Setup(t => t.From).Returns("From");
                mockTransaction.Setup(t => t.To).Returns("To");
                mockTransaction.Setup(t => t.Amount).Returns(100);

                chainblock.Add(mockTransaction.Object);
            }

            // Act
            int count = chainblock.Count;

            // Assert
            Assert.That(count, Is.EqualTo(n));
        }

        [Test]
        public void Count_ShouldReturnZero_WhenNoTransactionsAreAdded()
        {
            // Act
            int count = chainblock.Count;

            // Assert
            Assert.That(count, Is.EqualTo(0));
        }

        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Unauthorised)]
        public void ChangeTransactionStatus_ShouldBeSuccessful_WhenTransactionWithGivenIdExists(TransactionStatus newStatus)
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            // Act
            chainblock.ChangeTransactionStatus(mockTransaction.Object.Id, newStatus);

            // Assert
            Assert.That(mockTransaction.Object.Status, Is.EqualTo(newStatus));

            ITransaction returnedTransaction = chainblock.GetById(mockTransaction.Object.Id);
            Assert.That(returnedTransaction.Status, Is.EqualTo(newStatus));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrowArgumentException_WhenTransactionWithGivenIdDoesNotExist()
        {
            // Arrange
            TransactionStatus status = TransactionStatus.Failed;

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(999, status));
            Assert.That(exception.Message, Is.EqualTo("Transaction with the given ID does not exist."));
        }

        [Test]
        public void RemoveTransactionById_ShouldRemoveSuccessfully_WhenTransactionWithGivenIdExists()
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            // Act
            chainblock.RemoveTransactionById(mockTransaction.Object.Id);

            // Assert
            Assert.That(chainblock.Count, Is.Zero);
        }

        [Test]
        public void RemoveTransactionById_ShouldThrowInvalidOperationException_WhenTransactionWithGivenIdDoesNotExist()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(1));
            Assert.That(exception.Message, Is.EqualTo("Transaction with the given ID does not exist."));
        }

        [Test]
        public void GetById_ShouldReturnTransaction_WhenTransactionWithGivenIdExists()
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            // Act
            ITransaction returnedTransaction = chainblock.GetById(mockTransaction.Object.Id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(returnedTransaction.Id, Is.EqualTo(mockTransaction.Object.Id));
                Assert.That(returnedTransaction.Status, Is.EqualTo(mockTransaction.Object.Status));
                Assert.That(returnedTransaction.From, Is.EqualTo(mockTransaction.Object.From));
                Assert.That(returnedTransaction.To, Is.EqualTo(mockTransaction.Object.To));
                Assert.That(returnedTransaction.Amount, Is.EqualTo(mockTransaction.Object.Amount));
            });
        }

        [Test]
        public void GetById_ShouldThrowInvalidOperationException_WhenTransactionWithGivenIdDoesNotExist()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                ITransaction returnedTransaction = chainblock.GetById(1);
            });
            Assert.That(exception.Message, Is.EqualTo("Transaction with the given ID does not exist."));
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnCorrectCollection_WhenThereAreTransactionsInThisStatus()
        {
            // Arrange
            chainblock.Add(mockTransaction.Object);

            for (int i = 0; i < 5; i++)
            {
                ITransaction newTransaction = new Transaction(i + 10, TransactionStatus.Failed, "From", "To", 100 + i);
                chainblock.Add(newTransaction);
            }

            // Act
            List<ITransaction> returnedTransactions = chainblock
                .GetByTransactionStatus(TransactionStatus.Failed).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(returnedTransactions.Count, Is.EqualTo(5));

                Assert.That(returnedTransactions[0].Amount, Is.EqualTo(104));
                Assert.That(returnedTransactions[1].Amount, Is.EqualTo(103));
                Assert.That(returnedTransactions[2].Amount, Is.EqualTo(102));
                Assert.That(returnedTransactions[3].Amount, Is.EqualTo(101));
                Assert.That(returnedTransactions[4].Amount, Is.EqualTo(100));

                Assert.That(returnedTransactions[0].Status, Is.EqualTo(TransactionStatus.Failed));
                Assert.That(returnedTransactions[1].Status, Is.EqualTo(TransactionStatus.Failed));
                Assert.That(returnedTransactions[2].Status, Is.EqualTo(TransactionStatus.Failed));
                Assert.That(returnedTransactions[3].Status, Is.EqualTo(TransactionStatus.Failed));
                Assert.That(returnedTransactions[4].Status, Is.EqualTo(TransactionStatus.Failed));
            });
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowInvalidOperationException_WhenThereAreNoTransactionsInThisStatus()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                List<ITransaction> returnedTransactions = chainblock
                .GetByTransactionStatus(TransactionStatus.Failed).ToList();
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given status."));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnCorrectSenderNames_WhenThereAreTransactionsInThisStatus()
        {
            // Arrange
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction1.SetupProperty(tx => tx.From, "Kevin");
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction2.SetupProperty(tx => tx.From, "John");
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction3.SetupProperty(tx => tx.From, "John");
            transaction3.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.Status, TransactionStatus.Failed);
            transaction4.SetupProperty(tx => tx.From, "John");
            transaction4.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction5.SetupProperty(tx => tx.From, "Maria");
            transaction5.SetupProperty(tx => tx.Amount, 40);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<string> unauthorizedTransactions = chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorised).ToList();
            List<string> failedTransactions = chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Failed).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(unauthorizedTransactions.Count, Is.EqualTo(4));
                Assert.That(failedTransactions.Count, Is.EqualTo(1));

                Assert.That(unauthorizedTransactions, Is.EqualTo(new List<string>() { "Maria", "John", "John", "Kevin" }));
                Assert.That(failedTransactions, Is.EqualTo(new List<string>() { "John" }));
            });
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowInvalidOperationException_WhenThereAreNoTransactionsInThisStatus()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given status."));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnCorrectReceiverNames_WhenThereAreTransactionsInThisStatus()
        {
            // Arrange
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction1.SetupProperty(tx => tx.To, "Kevin");
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction2.SetupProperty(tx => tx.To, "John");
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction3.SetupProperty(tx => tx.To, "John");
            transaction3.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.Status, TransactionStatus.Failed);
            transaction4.SetupProperty(tx => tx.To, "John");
            transaction4.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.Status, TransactionStatus.Unauthorised);
            transaction5.SetupProperty(tx => tx.To, "Maria");
            transaction5.SetupProperty(tx => tx.Amount, 40);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<string> unauthorizedTransactions = chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorised).ToList();
            List<string> failedTransactions = chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Failed).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(unauthorizedTransactions.Count, Is.EqualTo(4));
                Assert.That(failedTransactions.Count, Is.EqualTo(1));

                Assert.That(unauthorizedTransactions, Is.EqualTo(new List<string>() { "Maria", "John", "John", "Kevin" }));
                Assert.That(failedTransactions, Is.EqualTo(new List<string>() { "John" }));
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowInvalidOperationException_WhenThereAreNoTransactionsInThisStatus()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given status."));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnCorrectCollection()
        {
            // Arrange
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 100);
            transaction3.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.Amount, 40);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction5.Object);
            chainblock.Add(transaction4.Object);

            // Act
            List<ITransaction> retrievedTransactions = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(retrievedTransactions.Count, Is.EqualTo(5));
                Assert.That(retrievedTransactions[0].Id, Is.EqualTo(4));
                Assert.That(retrievedTransactions[0].Amount, Is.EqualTo(40));
                Assert.That(retrievedTransactions[1].Id, Is.EqualTo(5));
                Assert.That(retrievedTransactions[1].Amount, Is.EqualTo(40));
                Assert.That(retrievedTransactions[2].Id, Is.EqualTo(100));
                Assert.That(retrievedTransactions[2].Amount, Is.EqualTo(40));
                Assert.That(retrievedTransactions[3].Id, Is.EqualTo(2));
                Assert.That(retrievedTransactions[3].Amount, Is.EqualTo(20));
                Assert.That(retrievedTransactions[4].Id, Is.EqualTo(1));
                Assert.That(retrievedTransactions[4].Amount, Is.EqualTo(10));
            });
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnCorrectCollection_WhenThereAreTransactionsWithThisSender()
        {
            // Arrange
            string kevin = "Kevin";
            string john = "John";

            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.From, kevin);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.From, john);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.From, john);
            transaction3.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.From, john);
            transaction4.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.From, kevin);
            transaction5.SetupProperty(tx => tx.Amount, 50);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<ITransaction> kevinTransactions = chainblock.GetBySenderOrderedByAmountDescending(kevin).ToList();
            List<ITransaction> johnTransactions = chainblock.GetBySenderOrderedByAmountDescending(john).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(kevinTransactions.Count, Is.EqualTo(2));
                Assert.That(kevinTransactions[0].Amount, Is.EqualTo(50));
                Assert.That(kevinTransactions[1].Amount, Is.EqualTo(10));

                Assert.That(johnTransactions.Count, Is.EqualTo(3));
                Assert.That(johnTransactions[0].Amount, Is.EqualTo(40));
                Assert.That(johnTransactions[1].Amount, Is.EqualTo(30));
                Assert.That(johnTransactions[2].Amount, Is.EqualTo(20));
            });
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowInvalidOperationException_WhenThereAreNoTransactionsWithThisSender()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetBySenderOrderedByAmountDescending("John");
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given sender."));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnCorrectCollection_WhenThereAreTransactionsWithThisReceiver()
        {
            // Arrange
            string john = "John";

            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.To, john);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.To, john);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.To, john);
            transaction3.SetupProperty(tx => tx.Amount, 50);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.To, john);
            transaction4.SetupProperty(tx => tx.Amount, 50);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.To, john);
            transaction5.SetupProperty(tx => tx.Amount, 50);

            Mock<ITransaction> transaction6 = new Mock<ITransaction>();
            transaction6.SetupProperty(tx => tx.Id, 6);
            transaction6.SetupProperty(tx => tx.To, "Kevin");
            transaction6.SetupProperty(tx => tx.Amount, 60);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);
            chainblock.Add(transaction6.Object);

            // Act
            List<ITransaction> transactions = chainblock.GetByReceiverOrderedByAmountThenById(john).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactions.Count, Is.EqualTo(5));
                Assert.That(transactions[0].Id, Is.EqualTo(3));
                Assert.That(transactions[0].Amount, Is.EqualTo(50));
                Assert.That(transactions[0].To, Is.EqualTo("John"));
                Assert.That(transactions[1].Id, Is.EqualTo(4));
                Assert.That(transactions[1].Amount, Is.EqualTo(50));
                Assert.That(transactions[1].To, Is.EqualTo("John"));
                Assert.That(transactions[2].Id, Is.EqualTo(5));
                Assert.That(transactions[2].Amount, Is.EqualTo(50));
                Assert.That(transactions[2].To, Is.EqualTo("John"));
                Assert.That(transactions[3].Id, Is.EqualTo(2));
                Assert.That(transactions[3].Amount, Is.EqualTo(20));
                Assert.That(transactions[3].To, Is.EqualTo("John"));
                Assert.That(transactions[4].Id, Is.EqualTo(1));
                Assert.That(transactions[4].Amount, Is.EqualTo(10));
                Assert.That(transactions[4].To, Is.EqualTo("John"));
            });
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowInvalidOperationException_WhenThereAreNoTransactionsWithThisReceiver()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetByReceiverOrderedByAmountThenById("John");
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given receiver."));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnCorrectCollection_WhenThereAreSuchTransactions()
        {
            // Arrange
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.Status, TransactionStatus.Successfull);
            transaction1.SetupProperty(tx => tx.Amount, 100);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.Status, TransactionStatus.Successfull);
            transaction2.SetupProperty(tx => tx.Amount, 110);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.Status, TransactionStatus.Successfull);
            transaction3.SetupProperty(tx => tx.Amount, 150);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.Status, TransactionStatus.Aborted);
            transaction4.SetupProperty(tx => tx.Amount, 110);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.Status, TransactionStatus.Successfull);
            transaction5.SetupProperty(tx => tx.Amount, 151);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<ITransaction> transactions = chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 150)
                .ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactions.Count, Is.EqualTo(3));
                Assert.That(transactions[0].Id, Is.EqualTo(3));
                Assert.That(transactions[0].Status, Is.EqualTo(TransactionStatus.Successfull));
                Assert.That(transactions[0].Amount, Is.EqualTo(150));
                Assert.That(transactions[1].Id, Is.EqualTo(2));
                Assert.That(transactions[1].Status, Is.EqualTo(TransactionStatus.Successfull));
                Assert.That(transactions[1].Amount, Is.EqualTo(110));
                Assert.That(transactions[2].Id, Is.EqualTo(1));
                Assert.That(transactions[2].Status, Is.EqualTo(TransactionStatus.Successfull));
                Assert.That(transactions[2].Amount, Is.EqualTo(100));
            });
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_WhenThereAreNoSuchTransactions()
        {
            // Act
            List<ITransaction> transactions = chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 150)
                .ToList();

            // Assert
            Assert.That(transactions, Is.Empty);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnCorrectCollection_WhenThereAreSuchTransactions()
        {
            // Arrange
            string kevin = "Kevin";
            string john = "John";

            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.From, kevin);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.From, john);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.From, john);
            transaction3.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.From, john);
            transaction4.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.From, john);
            transaction5.SetupProperty(tx => tx.Amount, 50);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<ITransaction> transactions = chainblock.GetBySenderAndMinimumAmountDescending(john, 20).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactions.Count, Is.EqualTo(3));
                Assert.That(transactions[0].Id, Is.EqualTo(5));
                Assert.That(transactions[0].Amount, Is.EqualTo(50));
                Assert.That(transactions[0].From, Is.EqualTo(john));
                Assert.That(transactions[1].Id, Is.EqualTo(4));
                Assert.That(transactions[1].Amount, Is.EqualTo(40));
                Assert.That(transactions[1].From, Is.EqualTo(john));
                Assert.That(transactions[2].Id, Is.EqualTo(3));
                Assert.That(transactions[2].Amount, Is.EqualTo(30));
                Assert.That(transactions[2].From, Is.EqualTo(john));
            });
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationException_WhenThereAreNoSuchTransactions()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetBySenderAndMinimumAmountDescending("John", 10);
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions satisfying the given filter."));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnCorrectCollection()
        {
            // Arrange
            string kevin = "Kevin";
            string john = "John";

            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.To, kevin);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.To, john);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 3);
            transaction3.SetupProperty(tx => tx.To, john);
            transaction3.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 4);
            transaction4.SetupProperty(tx => tx.To, john);
            transaction4.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.To, john);
            transaction5.SetupProperty(tx => tx.Amount, 50);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<ITransaction> transactions = chainblock.GetByReceiverAndAmountRange(john, 20, 30).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactions.Count, Is.EqualTo(3));
                Assert.That(transactions[0].Id, Is.EqualTo(3));
                Assert.That(transactions[0].Amount, Is.EqualTo(30));
                Assert.That(transactions[0].To, Is.EqualTo(john));
                Assert.That(transactions[1].Id, Is.EqualTo(4));
                Assert.That(transactions[1].Amount, Is.EqualTo(30));
                Assert.That(transactions[1].To, Is.EqualTo(john));
                Assert.That(transactions[2].Id, Is.EqualTo(2));
                Assert.That(transactions[2].Amount, Is.EqualTo(20));
                Assert.That(transactions[2].To, Is.EqualTo(john));
            });
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationException_WhenThereAreNoSuchTransactions()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetByReceiverAndAmountRange("John", 10, 20);
            });
            Assert.That(exception.Message, Is.EqualTo("There are no transactions with the given receiver."));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnCorrectCollection()
        {
            // Arrange
            Mock<ITransaction> transaction1 = new Mock<ITransaction>();
            transaction1.SetupProperty(tx => tx.Id, 1);
            transaction1.SetupProperty(tx => tx.Amount, 10);

            Mock<ITransaction> transaction2 = new Mock<ITransaction>();
            transaction2.SetupProperty(tx => tx.Id, 2);
            transaction2.SetupProperty(tx => tx.Amount, 20);

            Mock<ITransaction> transaction3 = new Mock<ITransaction>();
            transaction3.SetupProperty(tx => tx.Id, 400);
            transaction3.SetupProperty(tx => tx.Amount, 40);

            Mock<ITransaction> transaction4 = new Mock<ITransaction>();
            transaction4.SetupProperty(tx => tx.Id, 3);
            transaction4.SetupProperty(tx => tx.Amount, 30);

            Mock<ITransaction> transaction5 = new Mock<ITransaction>();
            transaction5.SetupProperty(tx => tx.Id, 5);
            transaction5.SetupProperty(tx => tx.Amount, 50);

            chainblock.Add(transaction1.Object);
            chainblock.Add(transaction2.Object);
            chainblock.Add(transaction3.Object);
            chainblock.Add(transaction4.Object);
            chainblock.Add(transaction5.Object);

            // Act
            List<ITransaction> transactions = chainblock.GetAllInAmountRange(20, 40).ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactions.Count, Is.EqualTo(3));
                Assert.That(transactions[0].Id, Is.EqualTo(2));
                Assert.That(transactions[0].Amount, Is.EqualTo(20));
                Assert.That(transactions[1].Id, Is.EqualTo(400));
                Assert.That(transactions[1].Amount, Is.EqualTo(40));
                Assert.That(transactions[2].Id, Is.EqualTo(3));
                Assert.That(transactions[2].Amount, Is.EqualTo(30));
            });
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollection_WhenThereAreNoSuchTransactions()
        {
            // Act
            List<ITransaction> transactions = chainblock.GetAllInAmountRange(20, 40).ToList();

            // Assert
            Assert.That(transactions, Is.Empty);
        }
    }
}