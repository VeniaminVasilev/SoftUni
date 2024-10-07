namespace SharkTaxonomy
{
    public class Classifier
    {
        private int _capacity;
        private List<Shark> _species;

        public int Capacity { get { return _capacity; } }
        public List<Shark> Species { get { return _species; } }

        public int GetCount { get { return _species.Count; } }

        public Classifier(int capacity)
        {
            _capacity = capacity;
            _species = new List<Shark>();
        }

        public void AddShark(Shark shark)
        {
            if (_capacity > _species.Count && !_species.Any(s => s.Kind == shark.Kind))
            {
                _species.Add(shark);
            }           
        }

        public bool RemoveShark(string kind)
        {
            if (_species.Any(s => s.Kind == kind))
            {
                Shark sharkToBeRemoved = _species.Find(s => s.Kind == kind);
                _species.Remove(sharkToBeRemoved);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetLargestShark()
        {
            Shark largestShark = _species.OrderByDescending(s => s.Length).FirstOrDefault();
            return largestShark.ToString();
        }

        public double GetAverageLength()
        {
            double averageLength = _species.Average(s => s.Length);
            return averageLength;
        }

        public string Report()
        {
            string report = $"{_species.Count} sharks classified:";

            for (int i = 0; i < _species.Count; i++)
            {
                report += $"\n{_species[i].ToString()}";
            }

            return report;
        }
    }
}