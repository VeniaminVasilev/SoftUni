using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ImportExpenseDto
    {
        [JsonProperty("ExpenseName")]
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string ExpenseName { get; set; } = null!;

        [JsonProperty("Amount")]
        [Required] // Required is set in order not to break when deserializing
        [Range(0.01, 100000.0)]  // set it this way to avoid CurrentCulture issues
        public decimal? Amount { get; set; }

        [JsonProperty("DueDate")]
        [Required]
        public string DueDate { get; set; } = null!;

        [JsonProperty("PaymentStatus")]
        [Required]
        public string PaymentStatus { get; set; } = null!;

        [JsonProperty("HouseholdId")]
        [Required] // Required is set in order not to break when deserializing
        public int? HouseholdId { get; set; }

        [JsonProperty("ServiceId")]
        [Required] // Required is set in order not to break when deserializing
        public int? ServiceId { get; set; }
    }
}
