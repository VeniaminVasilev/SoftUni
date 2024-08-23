using System.Globalization;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public int CalculateDifferenceInDays(string date1, string date2)
        {
            DateTime parsedDate1 = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime parsedDate2 = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

            TimeSpan difference = parsedDate1 - parsedDate2;

            return Math.Abs(difference.Days);
        }
    }
}