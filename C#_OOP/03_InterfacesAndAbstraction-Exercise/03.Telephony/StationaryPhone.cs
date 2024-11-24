namespace _03.Telephony
{
    public class StationaryPhone: ICaller
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}