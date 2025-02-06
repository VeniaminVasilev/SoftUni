using Logger.Interfaces;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(string dateTime, string reportLevel, string message)
        {
            string output = $"{dateTime} - {reportLevel} - {message}";
            return output;
        }
    }
}