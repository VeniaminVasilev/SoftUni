namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private readonly List<string> collection = new();

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string lastItem = this.collection.Last();
            this.collection.Remove(lastItem);
            return lastItem;
        }
    }
}