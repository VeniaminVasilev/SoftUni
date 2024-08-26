namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("The box is empty.");
            }

            T elementToBeRemoved = elements.Last();
            if (elementToBeRemoved != null)
            {
                elements.RemoveAt(elements.Count - 1);
            }
            return elementToBeRemoved;
        }

        public int Count { get { return elements.Count; } }
    }
}
