namespace _08.CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private readonly List<string> collection = new();
        
        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}