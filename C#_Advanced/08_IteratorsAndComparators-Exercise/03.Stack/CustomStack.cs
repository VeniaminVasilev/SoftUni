using System.Collections;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public CustomStack()
        {
            this.items = new List<T>();
        }

        public void Push(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                this.items.Add(list[i]);
            }
        }

        public void Pop()
        {
            if (this.items.Count == 0)
            {
                Console.WriteLine($"No elements");
            }
            else
            {
                items.RemoveAt(items.Count - 1);
            }
        }

        public void PrintAll()
        {
            if (this.items.Count > 0)
            {
                for (int i = this.items.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(items[i]);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
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