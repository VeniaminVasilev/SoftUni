namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> list)
        {
            this.items = list;
            this.index = 0;
        }

        public bool MoveNext()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.index++;

            return true;
        }

        public bool HasNext()
        {
            return this.index < this.items.Count - 1;
        }

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
            Console.WriteLine(this.items[this.index]);
        }
    }
}