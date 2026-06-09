using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoiceDto
    {
        [JsonProperty("Number")]
        [Required]
        [Range(1_000_000_000, 1_500_000_000)]
        public int Number { get; set; }

        [JsonProperty("IssueDate")]
        [Required]
        public string IssueDate { get; set; } = null!;

        [JsonProperty("DueDate")]
        [Required]
        public string DueDate { get; set; } = null!;

        [JsonProperty("Amount")]
        [Required]
        public decimal Amount { get; set; }

        [JsonProperty("CurrencyType")]
        [Required]
        public int CurrencyType { get; set; }

        [JsonProperty("ClientId")]
        [Required]
        public int ClientId { get; set; }
    }
}
