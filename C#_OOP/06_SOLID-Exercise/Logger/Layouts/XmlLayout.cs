using Logger.Interfaces;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(string dateTime, string reportLevel, string message)
        {
            string output = $"<log>\n   <date>{dateTime}</date>\n   <level>{reportLevel}</level>\n   <message>{message}</message>\n</log>";
            return output;
        }
    }
}