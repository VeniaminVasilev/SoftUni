namespace _08.CollectionHierarchy
{
    public class MyList : IAdd, IRemove, ICount
    {
        private readonly List<string> collection = new();

        public int Count => this.collection.Count;

        public int Add(string item)
        {
            this.collection.Add(item);
            return 0;
        }

        public string Remove()
        {
            string firstAddedItem = this.collection[collection.Count - 1];
            this.collection.Remove(firstAddedItem);
            return firstAddedItem;
        }
    }
}