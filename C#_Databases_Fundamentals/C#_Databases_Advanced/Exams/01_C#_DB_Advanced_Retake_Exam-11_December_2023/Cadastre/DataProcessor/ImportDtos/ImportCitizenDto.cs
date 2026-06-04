using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [JsonProperty("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [JsonProperty("LastName")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;

        [JsonProperty("BirthDate")]
        [Required]
        public string BirthDate { get; set; } = null!;

        [JsonProperty("MaritalStatus")]
        [Required]
        public string MaritalStatus { get; set; } = null!;

        [JsonProperty("Properties")]
        [Required]
        public List<int> Properties { get; set; } = null!;
    }
}
