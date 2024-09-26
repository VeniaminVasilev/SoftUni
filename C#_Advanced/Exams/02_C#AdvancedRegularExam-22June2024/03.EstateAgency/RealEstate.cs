namespace EstateAgency
{
    public class RealEstate
    {
        private string _address;
        private string _postalCode;
        private decimal _price;
        private double _size;

        public RealEstate(string address, string postalCode, decimal price, double size)
        {
            _address = address;
            _postalCode = postalCode;
            _price = price;
            _size = size;
        }

        public string Address { get { return _address; } }
        public string PostalCode { get { return _postalCode; } }
        public decimal Price { get { return _price; } }
        public double Size { get { return _size; } }

        public override string ToString()
        {
            return $"Address: {_address}, PostalCode: {_postalCode}, Price: ${_price}, Size: {_size} sq.m.";
        }
    }
}