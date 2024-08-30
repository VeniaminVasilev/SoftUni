namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public int CountGreaterThan(List<T> elements, T comparisonElement)
        {
            int count = 0;

            foreach (T element in elements)
            {
                if (element.CompareTo(comparisonElement) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}