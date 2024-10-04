namespace DataCenter
{
    public class Server
    {
        private string _serialNumber;
        private string _model;
        private int _capacity;
        private int _powerUsage;

        public string SerialNumber { get { return _serialNumber; } }
        public string Model { get { return _model; } }
        public int Capacity { get { return _capacity; } }
        public int PowerUsage { get { return _powerUsage; } }

        public Server (string serialNumber, string model, int capacity, int powerUsage)
        {
            _serialNumber = serialNumber;
            _model = model;
            _capacity = capacity;
            _powerUsage = powerUsage;
        }

        public override string ToString()
        {
            return $"Server {_serialNumber}: {_model}, {_capacity}TB, {_powerUsage}W";
        }
    }
}