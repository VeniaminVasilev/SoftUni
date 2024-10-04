using System.Text;

namespace DataCenter
{
    public class Rack
    {
        private int _slots;
        private List<Server> _servers;

        public int Slots { get { return _slots; } }
        public List<Server> Servers { get { return _servers; } }
        public int GetCount { get { return _servers.Count; } }

        public Rack(int slots)
        {
            _slots = slots;
            _servers = new List<Server>();
        }

        public void AddServer(Server server)
        {
            if (_slots > _servers.Count && !_servers.Any(s => s.SerialNumber == server.SerialNumber))
            {
                _servers.Add(server);
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            if (_servers.Any(s => s.SerialNumber == serialNumber))
            {
                Server serverToRemove = _servers.Find(s => s.SerialNumber == serialNumber);
                _servers.Remove(serverToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetHighestPowerUsage()
        {
            Server highestPowerUsageServer = _servers.OrderByDescending(s => s.PowerUsage).FirstOrDefault();
            return highestPowerUsageServer.ToString();
        }

        public int GetTotalCapacity()
        {
            int totalCapacity = _servers.Sum(s => s.Capacity);
            return totalCapacity;
        }

        public string DeviceManager()
        {
            string text = $"{_servers.Count} servers operating:";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _servers.Count; i++)
            {
                sb.Append($"\n{_servers[i].ToString()}");
            }
            text += sb.ToString();

            return text;
        }
    }
}