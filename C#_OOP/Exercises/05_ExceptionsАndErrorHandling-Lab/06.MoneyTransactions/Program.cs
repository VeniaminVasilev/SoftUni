namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] information = Console.ReadLine().Split(",");
            Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

            for (int i = 0; i < information.Length; i++)
            {
                string[] accountInfo = information[i].Split("-");
                string accountNumber = accountInfo[0];
                decimal balance = decimal.Parse(accountInfo[1]);
                accounts[accountNumber] = balance;
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                string accountNumber = tokens[1];
                decimal sum = decimal.Parse(tokens[2]);
                bool correctTransaction = true;

                try
                {
                    if (action != "Deposit" && action != "Withdraw")
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    if (!accounts.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (accounts[accountNumber] < sum && action == "Withdraw")
                    {
                        throw new ArgumentException("Insufficient balance!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    correctTransaction = false;
                }

                if (action == "Deposit" && correctTransaction)
                {
                    accounts[accountNumber] += sum;
                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }
                else if (action == "Withdraw" && correctTransaction)
                {
                    accounts[accountNumber] -= sum;
                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                }

                Console.WriteLine("Enter another command");
            }
        }
    }
}