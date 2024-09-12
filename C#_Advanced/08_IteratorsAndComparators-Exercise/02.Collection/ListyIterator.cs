using System.Collections;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public void PrintAll()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(string.Join(" ", this.items));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}