namespace EstateAgency
{
    public class EstateAgency
    {
        private int _capacity;
        private List<RealEstate> _realEstates;

        public int Count {  get { return _realEstates.Count; } }

        public EstateAgency(int capacity)
        {
            _capacity = capacity;
            _realEstates = new List<RealEstate>();
        }

        public int Capacity { get { return _capacity; } }
        public List<RealEstate> RealEstates { get { return _realEstates; } }

        public void AddRealEstate(RealEstate realEstate)
        {
            if (_capacity > _realEstates.Count)
            {
                if (!_realEstates.Any(re => re.Address == realEstate.Address))
                {
                    _realEstates.Add(realEstate);
                }
            }
        }

        public bool RemoveRealEstate(string address)
        {
            if (_realEstates.Any(re => re.Address == address))
            {
                RealEstate realEstateToBeRemoved = _realEstates.Find(re => re.Address == address);
                _realEstates.Remove(realEstateToBeRemoved);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {
            List<RealEstate> newList = new List<RealEstate>();

            for (int i = 0; i < _realEstates.Count; i++)
            {
                if (_realEstates[i].PostalCode == postalCode)
                {
                    newList.Add(_realEstates[i]);
                }
            }
            return newList;
        }

        public RealEstate GetCheapest()
        {
            RealEstate cheapest = _realEstates.OrderBy(re => re.Price).FirstOrDefault();
            return cheapest;
        }

        public double GetLargest()
        {
            double size = _realEstates.OrderByDescending(re => re.Size).FirstOrDefault().Size;
            return size;
        }

        public string EstateReport()
        {
            string report = "Real estates available:";

            for (int i = 0; i < _realEstates.Count; i++)
            {
                report += $"\n{_realEstates[i]}";
            }

            return report;
        }
    }
}