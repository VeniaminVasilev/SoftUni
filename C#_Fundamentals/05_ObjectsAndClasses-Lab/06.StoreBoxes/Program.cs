namespace MyNamespace
{
    public class Item
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }

    public class Box
    {
        public string BoxSerialNumber { get; set; }
        public string BoxItemName { get; set; }
        public int BoxItemQuantity { get; set;}
        public decimal BoxPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            List<Item> items = new List<Item>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end") { break; }

                string[] tokens = command.Split(" ");

                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);
                decimal boxPrice = itemQuantity * itemPrice;

                Box box = new Box();

                box.BoxSerialNumber = serialNumber;
                box.BoxItemName = itemName;
                box.BoxItemQuantity = itemQuantity;
                box.BoxPrice = boxPrice;

                boxes.Add(box);

                Item item = new Item();
                
                item.ItemName = itemName;
                item.ItemPrice = itemPrice;

                items.Add(item);
            }

            var sortedBoxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            for (int i = 0; i < sortedBoxes.Count; i++)
            {
                Console.WriteLine(sortedBoxes[i].BoxSerialNumber);
                Console.WriteLine($"-- {sortedBoxes[i].BoxItemName} - ${items.Find(x => x.ItemName == sortedBoxes[i].BoxItemName).ItemPrice:F2}: {sortedBoxes[i].BoxItemQuantity}");
                Console.WriteLine($"-- ${sortedBoxes[i].BoxPrice:F2}");
            }
        }
    }
}