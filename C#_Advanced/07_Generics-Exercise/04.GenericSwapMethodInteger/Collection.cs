namespace _04.GenericSwapMethodInteger
{
    public class Collection<T>
    {
        public List<T> Elements { get; set; }

        public Collection(List<T> elements)
        {
            Elements = elements;
        }

        public void SwapElementsAndPrint(int index1, int index2)
        {
            T elementAtIndex1 = Elements[index1];
            T elementAtIndex2 = Elements[index2];

            Elements.RemoveAt(index1);
            Elements.Insert(index1, elementAtIndex2);
            Elements.RemoveAt(index2);
            Elements.Insert(index2, elementAtIndex1);

            foreach (T element in Elements)
            {
                Console.WriteLine($"{element.GetType().ToString()}: {element}");
            }
        }
    }
}
