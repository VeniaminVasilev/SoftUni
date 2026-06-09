using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(9)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [JsonProperty("Price")]
        [Required]
        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [JsonProperty("CategoryType")]
        [Required]
        public int CategoryType { get; set; }
        
        [JsonProperty("Clients")]
        [Required]
        public List<int> Clients { get; set; } = new List<int>();
    }
}
