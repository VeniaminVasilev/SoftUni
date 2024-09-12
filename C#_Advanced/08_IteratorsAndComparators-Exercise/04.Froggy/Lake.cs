using System.Collections;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stoneNumbers;

        public Lake(List<int> numbers)
        {
            this.stoneNumbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stoneNumbers.Count; i += 2)
            {
                yield return stoneNumbers[i];
            }

            for (int i = stoneNumbers.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return stoneNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}