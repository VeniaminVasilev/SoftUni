namespace _03.MessagesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Statistics") { break; }

                string[] tokens = command.Split("=");
                string action = tokens[0];

                if (action == "Add")
                {
                    string username = tokens[1];
                    int sentMessages = int.Parse(tokens[2]);
                    int receivedMessages = int.Parse(tokens[3]);

                    bool userExists = users.Any(u => u.Name == username);

                    if (!userExists)
                    {
                        User newUser = new User(username, sentMessages, receivedMessages);
                        users.Add(newUser);
                    }
                }
                else if (action == "Message")
                {
                    string sender = tokens[1];
                    string receiver = tokens[2];

                    bool senderExists = users.Any(u => u.Name == sender);
                    bool receiverExists = users.Any(u => u.Name == receiver);

                    if (senderExists && receiverExists)
                    {
                        int indexSender = users.FindIndex(u => u.Name == sender);
                        int indexReceiver = users.FindIndex(u => u.Name == receiver);

                        users[indexSender].SentMessages++;
                        users[indexReceiver].ReceivedMessages++;

                        if (users[indexSender].SentMessages + users[indexSender].ReceivedMessages >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.RemoveAll(u => u.Name == sender);

                            indexReceiver = users.FindIndex(u => u.Name == receiver); // Update the index of the Receiver after deletion of the Sender.
                        }
                        
                        if (users[indexReceiver].SentMessages + users[indexReceiver].ReceivedMessages >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            users.RemoveAll(u => u.Name == receiver);
                        }
                    }
                }
                else if (action == "Empty")
                {
                    string username = tokens[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }
                    else if (users.Any(u => u.Name == username))
                    {
                        users.RemoveAll(u => u.Name == username);
                    }
                }
            }

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} - {user.SentMessages + user.ReceivedMessages}");
            }
        }

        public class User
        {
            public string Name { get; set; }
            public int SentMessages { get; set; }
            public int ReceivedMessages { get; set; }

            public User (string name, int sentMessages, int receivedMessages)
            {
                this.Name = name;
                this.SentMessages = sentMessages;
                this.ReceivedMessages = receivedMessages;
            }
        }
    }
}