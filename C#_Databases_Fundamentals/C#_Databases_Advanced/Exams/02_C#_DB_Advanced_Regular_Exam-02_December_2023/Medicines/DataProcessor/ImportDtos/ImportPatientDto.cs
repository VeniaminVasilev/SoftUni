using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [JsonProperty("AgeGroup")]
        [Required]
        public string AgeGroup { get; set; } = null!;

        [JsonProperty("Gender")]
        [Required]
        public string Gender { get; set; } = null!;
        
        [JsonProperty("Medicines")]
        [Required]
        public List<int> Medicines { get; set; } = null!;
    }
}
