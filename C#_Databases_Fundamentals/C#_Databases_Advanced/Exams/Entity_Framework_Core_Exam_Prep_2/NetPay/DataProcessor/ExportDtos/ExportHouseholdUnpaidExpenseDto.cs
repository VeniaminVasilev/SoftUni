using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Expense")]
    public class ExportHouseholdUnpaidExpenseDto
    {
        [XmlElement("ExpenseName")]
        public string ExpenseName { get; set; } = null!;

        [XmlElement("Amount")]
        public string Amount { get; set; } = null!;  // Use string for Amount as it will be formatted to the second decimal place

        [XmlElement("PaymentDate")]
        public string PaymentDate { get; set; } = null!;

        [XmlElement("ServiceName")]
        public string ServiceName { get; set; } = null!;
    }
}
