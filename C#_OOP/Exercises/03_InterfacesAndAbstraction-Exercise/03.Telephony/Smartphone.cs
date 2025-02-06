namespace _03.Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }
    }
}